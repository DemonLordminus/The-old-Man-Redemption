using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailboxEvent : eventElmentFather
{
    [SerializeField]
    public GetItem[] items;
    public bool BadOrGood;
    public int price;
    public override void getEventPerform()
    {

        if (OnLaw("邮箱是坏的") || OnAct("避开邮箱"))
        {
            if (BadOrGood)
            {
                GoodRun();
            }
            else
            {
                BadRun();
            }
        }
        else
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
    void GoodRun()
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        //不花费财富值
        //老人会将遇到上一个邮局之后的事件记录写成信件发给玩家
        //会提供中级信纸，有概率提供高级信纸
        if (Random.Range(1,7)>4)
        {
            DataManager.instance.controller.AddNewItem(items);
        }
        else
        {
            DataManager.instance.controller.AddNewItem(items);
        }
    }

    void BadRun()
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        //需要财富值才提供服务
        //老人的邮件有概率出现损坏，即上一半或下一半消失
        if (DataManager.instance.controller.Gold > price)
        {
            //会提供低级信纸，有概率提供中级信纸
            if (Random.Range(1,7)>4)
            { DataManager.instance.controller.AddNewItem(items);}
            else
            { DataManager.instance.controller.AddNewItem(items);}
            DataManager.instance.controller.Gold -= price;
        }
    }
}
