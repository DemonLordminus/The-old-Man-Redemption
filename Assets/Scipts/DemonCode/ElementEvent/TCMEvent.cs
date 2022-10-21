using Dmld;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCMEvent : eventElmentFather
{
    [SerializeField]
    public GetItem[] items;
    public bool BadOrGood;
    public int price;
    public float escapeF;
    public override void getEventPerform()
    {

        if (OnLaw("中医院是坏的") || OnAct("避开中医院"))
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
        //付出一定财富值后可以获得道具中药
        if (DataManager.instance.controller.Gold > price)
        {
            DataManager.instance.controller.AddNewItem(items[0]);
            DataManager.instance.controller.Gold -= price;
            return;
        }
        //财富值不足时，有概率获得一份草药作为补贴，草药的效果为恢复健康值和体能值
        else if (Random.Range(1,7)>4)
        {
            DataManager.instance.controller.AddNewItem(items[1]);
        }
        //若财富值不足且未获得草药补贴，降低心情值
        DataManager.instance.controller.ChangeBP(-10);
    }

    void BadRun()
    {
        bool escape = Random.Range(0,escapeF) > 5;
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        //老人识破坑钱并跑路的概率默认为0
        if (escape)
        {
            return;
        }
        //需要的财富值比正规中医院稍贵
        else if (DataManager.instance.controller.Gold > 1.2*price)
        {
            DataManager.instance.controller.AddNewItem(items[1]);
            DataManager.instance.controller.Gold -= (float)1.2 * price;
            DataManager.instance.controller.ChangeBP(5);
            return;
        }
        DataManager.instance.controller.ChangeBP(-10);
    }
}
