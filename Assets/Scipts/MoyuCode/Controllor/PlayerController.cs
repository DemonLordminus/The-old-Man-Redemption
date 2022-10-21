using System;
using UnityEngine;
using Random = UnityEngine.Random;
using Dmld;
using System.Collections;
using Cinemachine;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;

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
        Initialize();
        animator = GetComponent<Animator>();
        isPalse = false;
        CurrentBp = MaxBp;
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
        if (CurrentSp >= MaxSp / 1.01 && isRun == false)
        {
            isRun = true;
        }
    }
    public float mangmuTime;
    void FixedUpdate()
    {
        if (!isPalse)
        {
            if (debuffs[9].isEnable)
            {
                if (debuffs[9].keepTime > 116)
                {
                    mangmuTime = -1;
                }
                else if (debuffs[9].keepTime > 50)
                {
                    mangmuTime = 0f;
                }
                else
                {
                    mangmuTime = 1 / 10f;
                }
                virtualCamera.m_Lens.OrthographicSize = Mathf.Clamp(virtualCamera.m_Lens.OrthographicSize + mangmuTime * Time.fixedDeltaTime, 2, 5);
            }
            if (CurrentSp < MaxSp / 9 && debuffs[4].isEnable)
            {
                ChangeHealth(-1);
            }
            //切换速度，使得在体力条小于10%不能奔跑，跑步消耗体力，走路休息恢复体力
            if ((CurrentSp > MaxSp / 10 && isRun) && x != 0 && !debuffs[2].isEnable)//fali)
            {
                currentspeed = maxspeed;
                ChangeSp(-1);
            }
            else
            {
                if (debuffs[4].isEnable)//huxikunnan)
                {
                    ChangeSp(1);
                }
                else
                {
                    ChangeSp(2);
                }
                currentspeed = maxspeed / 2;
                isRun = false;
            }
            Move(x);
            if (debuffs[1].isEnable)//fare)
            {
                ChangeSp(-1);
            }
            if (debuffs[3].isEnable)//outufuxie)
            {
                ChangeHealth(Convert.ToInt32(-1 - debuffs[3].keepTime / 10));
            }
            if (debuffs[7].isEnable)//yiyu
            {
                ChangeBP(-2);
            }
            //计时器
            Timer -= Time.fixedDeltaTime;
            if (Timer <= 0)
            {
                //初始化
                x = Random.Range(0, 2);
                if (debuffs[0].isEnable)//zhongdu)
                {
                    ChangeHealth(-2);
                }
                if (debuffs[1].isEnable)//fare)
                {
                    MaxSp -= 5;
                }
                Timer = 1.5f;
                NewSpeed();
            }
            if (debuffs[6].isEnable && debuffs[6].keepTime - CurrentTime > 5)//jianwang)
            {
                Jianwang();
                CurrentTime = debuffs[6].keepTime;
            }
            UpdateDebuffTime();
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
        if (debuffs[2].isEnable)//fali)
        {
            position.x = position.x + currentspeed / 2 * i * Time.fixedDeltaTime;
        }
        else
        {
            position.x = position.x + currentspeed * i * Time.fixedDeltaTime;
        }
        Rigidbody2D.position = position;
        animator.SetFloat("MoveX", currentspeed);
    }
    #endregion

    #region 数值系统
    public float MaxHealthy;
    public float CurrentHealthy;
    public float MaxSp;
    public float CurrentSp;
    public float MaxBp;//幸福值
    public float CurrentBp;
    public float Gold;
    public float CurrentTime;//处理健忘

    public void ChangeHealth(float amount)
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

    public void ChangeSp(float amount)
    {
        CurrentSp = Mathf.Clamp(CurrentSp + amount, 0, MaxSp);
        SpBarManager.Instance.SetValue(CurrentSp / (float)MaxSp);
    }

    public void ChangeBP(float amount)
    {
        CurrentBp = Mathf.Clamp(CurrentBp + amount, 0, MaxBp);
        BlissBarManager.Instance.SetValue(CurrentBp / (float)MaxBp);
    }


    #endregion
    #region debuff
    //0=中毒
    //1=发热
    //2=乏力
    //3=呕吐腹泻
    //4=呼吸困难
    //5=混乱
    //6=健忘
    //7=抑郁
    //8=焦躁
    //9=盲目

    public CinemachineVirtualCamera virtualCamera;
    public DebuffClass[] debuffs;

    [HideInInspector]
    public const int maxDebuffNum = 10;//最大病症数量

    void Initialize()
    {
        debuffs = new DebuffClass[maxDebuffNum];
        for (int order = 0; order < maxDebuffNum; ++order)
        {
            debuffs[order] = new DebuffClass(order);
        }
    }
    void UpdateDebuffTime()
    {
        foreach (DebuffClass debuff in debuffs)
        {
            if (debuff.keepTime > 0)
            {
                debuff.keepTime -= Time.fixedDeltaTime;
                if (debuff.keepTime < 0)
                {
                    debuff.isEnable = false;
                    debuff.keepTime = 0;
                }
            }
        }
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
    public bool IsTrue;
    public bool Isrun;
    public string whatEnemy;
    public List<GetItem> ItemsPackage;
    public bool IfHunluan()
    {
        if (debuffs[5].isEnable && Random.Range(1, 7) < 5)
        {
            return false;
        }
        return true;
    }
    public int num;
    void Jianwang()
    {
        DataManager.instance.lawOrActLists.lawlists.RemoveRange(((int)Random.Range(0,DataManager.instance.lawOrActLists.lawlists.Count/3))*3,3);
    }
    public bool Probability(int amount)
    {
        if (Random.Range(0, 101) < amount)
        {
            return true;
        }
        return false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "mailbox")
        {
            collision.gameObject.GetComponent<eventElmentFather>().getEventPerform(); return;
        }
        if(IfHunluan())
        {
            OnEvent(collision);
        }
        else
        {
            collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
     #region 老代码
        /*if (propsController != null)//判断为物品
        {
            if (IfHunluan())
            {
                GetItem = propsController.GetItem;
                Package = propsController.Package;
                switch (GetItem.Name)//根据GetItem组件中的Name属性来判断是否运行
                {
                    case "Yaoping":
                        IsTrue = (citiaos[14] && citiaos[17] && citiaos[1] || citiaos[0] && citiaos[15]) && Isrun;
                        if (citiaos[0])
                        {
                            citiaos[15] = false;
                        }; break;
                    case "xin":; collision.gameObject.GetComponent < AddNewItem()BoxCollider2D > ().isTrigger = true; return;
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
                    Destroy(collision.gameObject);
                    Destroy(collision.transform.parent.gameObject);
                }
            }
            else
            {
                collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            }
        }
        else if (enemyController != null)
        {
            if (IfHunluan())
            {
                IsTrue = (citiaos[12] && citiaos[17] && citiaos[1] || citiaos[13] && citiaos[0]) && Isrun;
                if (citiaos[0])
                {
                    citiaos[13] = false;
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
                    whatEnemy = enemyController.whatEnemy;
                    Destroy(collision.gameObject);
                    Destroy(collision.transform.parent.gameObject);
                }
            }
            else
            {
                ChangeHealth(-10);
                whatEnemy = enemyController.whatEnemy;
                Destroy(collision.gameObject);
                Destroy(collision.transform.parent.gameObject);
            }
        }*/
        #endregion

    }
    void OnEvent(Collision2D collision)
    {
        if (collision.gameObject.tag == "EventElement")
        {
            collision.gameObject.GetComponent<eventElmentFather>().getEventPerform();
        }
    }
    #endregion

    #region 获取
    public void AddNewItem(GetItem item)
    {
        if (!ItemsPackage.Contains(item))
        {
            item.Num = 1;
            ItemsPackage.Add(item);

        }
        else
        {
            item.Num++;
        }
        PackageManager.RefreshItem();

    }
    public void AddNewItem(GetItem[] Item)
    {
        foreach (GetItem item in Item)
        {
            if (!ItemsPackage.Contains(item))
            {
                item.Num = 1;
                ItemsPackage.Add(item);

            }
            else
            {
                item.Num++;
            }
        }
        PackageManager.RefreshItem();

    }
    #endregion
}
