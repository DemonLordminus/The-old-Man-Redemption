using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D Rigidbody2d;
    //�����յ���Ϸ����
    GameObject IfGreen;
    GameObject IfGuaiwu;
    //���������жϱ���
    public bool Green;
    public bool Guaiwu;
    public bool IsTrue;
    private void Start()
    {
        Rigidbody2d = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�������жϻ�ȡֵ
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
