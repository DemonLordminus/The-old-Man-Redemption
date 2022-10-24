using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MailboxEvent : eventElmentFather
{
    [SerializeField]
    public GetItem[] items;
    //public bool BadOrGood;
    public int price;
    public bool ishave;
    public override void getEventPerform()
    {

        if (!OnLaw("邮箱是坏的") || !OnAct("避开邮箱"))
        {
            OnPresent();
            if (isGood && ishave)
            {
                information += "老人遇到了邮箱";
                GoodRun();
            }
            else
            {
                information += "老人遇到了黑心邮箱";
                BadRun();
            }
            DataManager.instance.eventFinishing.Add(information);
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
        if (Random.Range(0,100)>random)
        {
            DataManager.instance.controller.AddNewItem(items);
        }
        else
        {
            DataManager.instance.controller.AddNewItem(items);
        }
        if(ishave)
        {
            DataManager.instance.controller.Isrun = true;
            ishave = false;
        }
        information += "，获得了一些信纸";
    }

    void BadRun()
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        //需要财富值才提供服务
        //老人的邮件有概率出现损坏，即上一半或下一半消失
        if (DataManager.instance.controller.Gold > price)
        {
            //会提供低级信纸，有概率提供中级信纸
            if (Random.Range(0,100)>random)
            { DataManager.instance.controller.AddNewItem(items);}
            else
            { DataManager.instance.controller.AddNewItem(items);}
            DataManager.instance.controller.Gold -= price;
        }
        information += "，花费一些金钱购买了拙劣的信纸";
    }
    void OnPresent()
    {
        foreach(string eventInformation in DataManager.instance.eventFinishing)
        {
            DataManager.instance.endFinishin.Add(eventInformation);
            DataManager.instance.allEvent.transform.GetChild(0).gameObject.GetComponent<Text>().text += "\n"+eventInformation;
        }
        try
        {
            DataManager.instance.allEvent.SetActive(true);
            DataManager.instance.controller.isPalse = true;
        }
        catch
        { }
        DataManager.instance.eventFinishing.Clear();
    }
}
