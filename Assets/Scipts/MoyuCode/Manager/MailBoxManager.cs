using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MailBoxManager : MonoBehaviour
{
    public bool ishave;
    public bool isrun;
    private void Start()
    {
        //��ʼ��
        ishave = false;
        isrun = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player" && ishave == true)//���˴�����������������
        {
            ishave=false;
            isrun =true;
            this.GetComponent<BoxCollider2D>().isTrigger=true;//ʹ�����ܴ���
        }
        if(collision.gameObject.tag=="Player")
        {
            this.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
}
