using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;

public class PlayerController : MonoBehaviour
{
    #region  移动
    Animator animator;
    //声明速度变量
    public bool isPalse;
    public float maxspeed;
    public float currentspeed;
    public bool isRun;
    //声明刚性对象
    Rigidbody2D Rigidbody2D;
    //声明随机量
    int x;
    //计时器
    float Timer;
    //声明位置
    private Vector2 Vector2;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isPalse = false;
        CurrentHealthy = MaxHealthy;
        CurrentSp = MaxSp;
        currentspeed = maxspeed;
        isRun = true;
        //分别获取游戏对象
        x = Random.Range(0, 2);
        //获取刚性
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        OpenMyBag();
    }
    //初始化速度
    void NewSpeed()
    {
        if (CurrentSp == MaxSp && isRun == false)
        {
            isRun = true;
        }
    }
    void FixedUpdate()
    {
        if (!isPalse)
        {
            //切换速度，使得在体力条小于10%不能奔跑，跑步消耗体力，走路休息恢复体力
            if ((CurrentSp > MaxSp / 10 && isRun) && x != 0)
            {
                currentspeed = maxspeed;
                ChangeSp(-1);
            }
            else
            {
                currentspeed = maxspeed / 2;
                ChangeSp(2);
                isRun = false;
            }
            Move(x);
            //计时器
            Timer -= Time.fixedDeltaTime;
            if (Timer <= 0)
            {
                //初始化
                x = Random.Range(0, 2);
                Timer = 1.5f;
                NewSpeed();
            }
        }
        else
        {
            Move(0);
        }
    }
    //移动
    public void Move(int i)
    {
        if (i == 0)
        { currentspeed = 0; }
        //获取当前对象所在位置
        Vector2 position = transform.position;
        position.x = position.x + currentspeed * i * Time.fixedDeltaTime;
        Rigidbody2D.position = position;
        animator.SetFloat("MoveX", currentspeed);
    }
    #endregion

    #region 数值系统
    public float MaxHealthy;
    public float CurrentHealthy;
    public float Wealthy;
    public float MaxSp;
    public float CurrentSp;
    public float HappinessIndex;
    public float Gold;

    public void ChangeHealth(int amount)
    {
        CurrentHealthy = Mathf.Clamp(CurrentHealthy + amount, 0, MaxHealthy);
        HealthyBarManager.Instance.SetValue(CurrentHealthy / (float)MaxHealthy);
        if (CurrentHealthy <= 0)
        {
            isDie = true;
            Time.timeScale = 0f;
            gameOver.SetActive(isDie);
        }
    }

    public void ChangeSp(int amount)
    {
        CurrentSp = Mathf.Clamp(CurrentSp + amount, 0, MaxSp);
        SpBarManager.Instance.SetValue(CurrentSp / (float)MaxSp);
    }
    #endregion

    #region 切换UI
    public GameObject myBar;
    public GameObject myBag;
    bool isOpean;
    bool isDie;
    void OpenMyBag()
    {
        if (!isPalse)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                isOpean = !isOpean;
                myBar.SetActive(isOpean);
                myBag.SetActive(!isOpean);
            }
        }
    }
    #endregion

    public GameObject gameOver;
    #region 碰撞
    public bool avoid;
    public bool bad;
    public bool cabinets;
    public bool eat;
    public bool entry;
    public bool exercise;
    public bool good;
    public bool hospital;
    public bool HRM;
    public bool illness_bad;
    public bool illness_avoid;
    public bool pharmacy_bad;
    public bool pharmacy_avoid;
    public bool relax;
    public bool shi;
    public bool TCM;
    public bool IsTrue;
    public bool Isrun;
    public GetItem GetItem;
    public Package Package;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //判断是否接收到信
        Isrun = GameObject.FindWithTag("mailbox").GetComponent<MailBoxManager>().isrun;
        EnemyManager enemyController = collision.gameObject.GetComponent<EnemyManager>();
        MailBoxManager mailBoxManager = collision.gameObject.GetComponent<MailBoxManager>();
        PropsController propsController = collision.gameObject.GetComponent<PropsController>();
        if (propsController != null)//判断为物品
        {
            GetItem = collision.gameObject.GetComponent<PropsController>().GetItem;
            Package = collision.gameObject.GetComponent<PropsController>().Package;
            switch (GetItem.Name)//根据GetItem组件中的Name属性来判断是否运行
            {
                case "Yaoping":
                    IsTrue = (pharmacy_bad && shi && bad || avoid && pharmacy_avoid) && Isrun;
                    if (avoid)
                    {
                        pharmacy_avoid = false;
                    }; break;
                default: break;
            }
            if (IsTrue)
            {
                collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
                return;
            }
            else
            {
                if (GetItem.Name == "Yaoping")
                {
                    collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
                    if (Gold > 50)
                    {
                        AddNewItem();
                        Gold -= 50;
                    }
                    return;
                }
                AddNewItem();
                Destroy(this.gameObject);
                Destroy(this.transform.parent.gameObject);
            }
        }
        else if (enemyController != null)
        {
            IsTrue = (illness_bad && shi && bad || illness_avoid && avoid) && Isrun;
            if (avoid)
            {
                illness_avoid = false;
            }
            if (IsTrue)
            {
                try
                {
                    collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
                }
                catch
                { };

            }
            else
            {
                ChangeHealth(-10);
                Destroy(collision.gameObject);
                Destroy(collision.transform.parent.gameObject);
            }
        }

    }
    #endregion

    #region 获取
    public void AddNewItem()
    {
        if (!Package.Items.Contains(GetItem))
        {
            GetItem.Num = 1;
            Package.Items.Add(GetItem);
        }
        else
        {
            GetItem.Num += 1;
        }
        PackageManager.RefreshItem();
    }
    #endregion
}
