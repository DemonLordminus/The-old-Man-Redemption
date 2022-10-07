using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyController : MonoBehaviour
{
    
    private void Start()
    {
        Rigidbody2D Rigidbody2d = GetComponent<Rigidbody2D>();
    }
    #region 碰撞
    //声明空的游戏对象
    GameObject IfGreen;
    GameObject IfGuaiwu;
    //声明两个判断变量
    public bool Green;
    public bool Guaiwu;
    public bool IsTrue;
    public bool Isshi;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //给两个判断获取值
        try
        {
            IfGreen = GameObject.FindWithTag("Green");
            IfGuaiwu = GameObject.FindWithTag("Guaiwu");
            Green = IfGreen.GetComponent<Green>().Isgreen;
            Guaiwu = IfGuaiwu.GetComponent<Guaiwu>().Isguaiwu;
            Isshi = GameObject.FindWithTag("shi").GetComponent<Shi>().Isshi;
        }
        catch
        { }
        PlayerController playerController =collision.gameObject.GetComponent<PlayerController>();
        IsTrue = Guaiwu && Green&Isshi;
        if (IsTrue)
        {
            try
            {
                this.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            }
            catch
            { };

        }
        if (playerController != null && !IsTrue)
        {
            playerController.ChangeHealth(-10);
            Destroy(this.gameObject);
            Destroy(this.transform.parent.gameObject);
        }
    }
    #endregion

}
