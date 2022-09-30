using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;

public class PlayerController : MonoBehaviour
{
    #region 实现随机移动即寻怪
    //声明空的游戏对象
    GameObject IfGreen;
    GameObject IfGuaiwu;
    //声明两个判断变量
    public bool Green ;
    public bool Guaiwu ;
    //声明一个游戏对象
    GameObject playobject;
    //声明速度变量
    public float speed;
    //声明跳跃力度
    public float jumpVelocity = 0.5f;
    //声明刚性对象
    Rigidbody2D Rigidbody2D;
    //获取左右方向
    Vector2 lookdirection = new Vector2(1, 0);
    Vector2 lookdirection1 = new Vector2(-1, 0);
    //声明随机量
    int x ;
    //计时器
    float Timer;
    //声明位置
    private Vector2 Vector2;
    // Start is called before the first frame update
    void Start()
    {
        //分别获取游戏对象
        x = Random.Range(-1, 2);
        playobject = GameObject.Find("Sprite-0003");
        //获取刚性
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //发出射线判断左右1f内是否存在图层为“Map”的对象
        RaycastHit2D hit = Physics2D.Raycast(Rigidbody2D.position + Vector2.up * 0.2f, lookdirection,1f, LayerMask.GetMask("Map"));
        RaycastHit2D hit1 = Physics2D.Raycast(Rigidbody2D.position + Vector2.up * 0.2f, lookdirection1, 1f, LayerMask.GetMask("Map"));
        if (hit.collider != null||hit1.collider !=null)//左右任一有阻挡就跳跃
        {
            //施加力使之完成跳跃
            Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x, jumpVelocity * Time.deltaTime);
        }
        //给两个判断获取值
        try
        {
            IfGreen = GameObject.FindWithTag("Green");
            IfGuaiwu = GameObject.FindWithTag("Guaiwu");
            Green =IfGreen.GetComponent<Green>().Isgreen;
            Guaiwu = IfGuaiwu.GetComponent<Guaiwu>().Isguaiwu;
        }
        catch
        { }
        if (Green && Guaiwu)//两个同时成立
        {
            //趋向物体移动
            transform.position = Vector2.MoveTowards(transform.position, playobject.transform.position, speed * Time.deltaTime);
        }
        else
        {
            //调用Move这个方法
            Move(x);
            //计时器
            Timer -= Time.fixedDeltaTime;
            if (Timer <= 0)
            {
                //初始化
                x = Random.Range(-1, 2);
                Timer = 1.5f;
            }

        }

    }
    //移动
    public void Move(int i)
    {
        //获取当前对象所在位置
        Vector2 position = transform.position;
        position.x = position.x + speed * i * Time.fixedDeltaTime;
        Rigidbody2D.position = position;
    }
    #endregion
}
