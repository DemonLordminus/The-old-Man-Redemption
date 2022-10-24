using Dmld;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;

public class PharmacyEvent : eventElmentFather
{
    [SerializeField]
    public GetItem[] items;
    //public bool BadOrGood;
    public int price;
    public int inlit;
    public override void getEventPerform()
    {

        if (!OnLaw("药店是坏的") || !OnAct("避开药店"))
        {
            if (isGood)
            {
                information += "老人遇到了药店";
                GoodRun();
            }
            else
            {
                information += "老人遇到了黑心药店";
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
        //如有财富值，付出一定财富值购入多种药品
        if (DataManager.instance.controller.Gold>50)
        {
            foreach(var item in items)
            {
                if (DataManager.instance.controller.ItemsPackage.Count < inlit)
                {
                    DataManager.instance.controller.AddNewItem(item);
                    DataManager.instance.controller.Gold -= price;
                }
                else
                {
                    break;
                }
            }
            information += "，购买了一些药品";
        }
        else
        {
            DataManager.instance.controller.ChangeBP(-10);
            information += "，但无力购买，心情低落";
        }
    }

    void BadRun()
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        //如果财富值足够，进行随机，有概率老人自行醒悟，退出避免被坑
        if (DataManager.instance.controller.Gold > 2 * price && Random.Range(0, 100) > random)
        {
            information += "，但老人敏锐地识破，并未进入";
            return;
        }
        //价格很高，消耗的财富值很多
        else 
        {
            foreach(var item in items)
            {
                if (DataManager.instance.controller.ItemsPackage.Count < inlit)
                {
                    DataManager.instance.controller.AddNewItem(item);
                    DataManager.instance.controller.Gold -= 2*price;
                }
                else
                {
                    break;
                }
            }
        }
        DataManager.instance.controller.ChangeBP(-10);
        information += "，花费更高的价格购买药品，心情低落";
    }
}
