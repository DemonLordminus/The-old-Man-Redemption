using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailboxEvent : eventElmentFather
{
    public bool ishave;
    public override void getEventPerform()
    {
        if (ishave == true)//老人触发并且信箱内有信
        {
            ishave = false;
            DataManager.instance.controller.Isrun=true;
        }
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;//使主角能穿过
    }
}
