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
}
