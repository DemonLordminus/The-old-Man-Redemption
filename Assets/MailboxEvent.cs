using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailboxEvent : eventElmentFather
{
    public bool ishave;
    public override void getEventPerform()
    {
        if (ishave == true)//���˴�����������������
        {
            ishave = false;
            DataManager.instance.controller.Isrun=true;
        }
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;//ʹ�����ܴ���
    }
}
