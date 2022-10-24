using Dmld;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCMEvent : eventElmentFather
{
    [SerializeField]
    public GetItem[] items;
    //public bool BadOrGood;
    public int price;
    public override void getEventPerform()
    {

        if (!OnLaw("中医院是坏的") || !OnAct("避开中医院"))
        {
            if (isGood)
            {
                information += "老人遇到了中医院";
                GoodRun();
            }
            else
            {
                information += "老人遇到了黑心中医院";
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
        //付出一定财富值后可以获得道具中药
        if (DataManager.instance.controller.Gold > price)
        {
            DataManager.instance.controller.AddNewItem(items[0]);
            DataManager.instance.controller.Gold -= price;
            information += "，花费一定钱财获得了中药";
            return;
        }
        //财富值不足时，有概率获得一份草药作为补贴，草药的效果为恢复健康值和体能值
        else if (Random.Range(0,100)>random)
        {
            DataManager.instance.controller.AddNewItem(items[1]);
            information += "，虽然钱不足，但获得了草药作为补贴";
        }
        //若财富值不足且未获得草药补贴，降低心情值
        DataManager.instance.controller.ChangeBP(-10);
        information += "，但钱不够，心情低落";
    }

    void BadRun()
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        //老人识破坑钱并跑路的概率默认为0
        if (Random.Range(0, 100) < random) 
        {
            information += "，但老人敏锐地识破，并成功跑路";
            return;
        }
        //需要的财富值比正规中医院稍贵
        else if (DataManager.instance.controller.Gold > 1.2f*price)
        {
            DataManager.instance.controller.AddNewItem(items);
            DataManager.instance.controller.Gold -= 1.2f * price;
            DataManager.instance.controller.ChangeBP(5);
            information += "，虽然花费了更多的价钱，但在心理作用心情还不错";
            return;
        }
        information += "，什么都没有干，心情低落";
        DataManager.instance.controller.ChangeBP(-10);
    }
}
