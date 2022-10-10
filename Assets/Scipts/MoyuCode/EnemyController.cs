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
    #region ��ײ
    //�����յ���Ϸ����
    GameObject IfGreen;
    GameObject IfGuaiwu;
    //���������жϱ���
    public bool Green;
    public bool Guaiwu;
    public bool IsTrue;
    public bool Isshi;
    public bool Isrun;
    private void Update()
    {
        //�������жϻ�ȡֵ
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
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Isrun = GameObject.FindWithTag("mailbox").GetComponent<MailBoxManager>().isrun;
        PlayerController playerController =collision.gameObject.GetComponent<PlayerController>();
        IsTrue = Guaiwu && Green&&Isshi&& Isrun;
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
