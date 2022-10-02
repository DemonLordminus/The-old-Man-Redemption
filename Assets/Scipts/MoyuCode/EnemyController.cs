using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D Rigidbody2d;
    //声明空的游戏对象
    GameObject IfGreen;
    GameObject IfGuaiwu;
    //声明两个判断变量
    public bool Green;
    public bool Guaiwu;
    public bool IsTrue;
    private void Start()
    {
        Rigidbody2d = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //给两个判断获取值
        try
        {
            IfGreen = GameObject.FindWithTag("Green");
            IfGuaiwu = GameObject.FindWithTag("Guaiwu");
            Green = IfGreen.GetComponent<Green>().Isgreen;
            Guaiwu = IfGuaiwu.GetComponent<Guaiwu>().Isguaiwu;
        }
        catch
        { }
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        IsTrue = Guaiwu&&Green;
        if(IsTrue)
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
            return;
        }
        if (playerController != null && !IsTrue )
        {
            playerController.ChangeHealth(-10);
            Destroy(this.gameObject);
            Destroy(this.transform.parent.gameObject);
        }
    }

    
}
