using Dmld;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpEvent : eventElmentFather
{
    [SerializeField]
    public GetItem[] items;
    //public bool BadOrGood;
    public int price;
    [Header("背包获取的界限")]
    public int inlit;
    public int upBp;
    public override void getEventPerform()
    {
        information = "";
        if (!OnLaw("援助处是坏的") || !OnAct("避开援助处"))
        {
            if (isGood)
            {
                information += "老人遇到了援助处，";
                GoodRun();
            }
            else
            {
                information += "老人遇到了黑心援助处，";
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
        //免费，提供各种食品、杂志、药物等道具
        //如果老人背包内物品多，则不会拿取
        if (DataManager.instance.controller.ItemsPackage.Count > inlit)
        {
            //如果老人背包内物品多且心情值低，则会随机将包里的非药品物品捐出，会增加心情值
            if (DataManager.instance.controller.CurrentBp < inlit)
            {
                DataManager.instance.controller.ItemsPackage.RemoveAt(Random.Range(0, DataManager.instance.controller.ItemsPackage.Count));
                DataManager.instance.controller.CurrentBp += upBp;
                information += "将自己背包里多余的东西捐了出去";
            }
            return;
        }
        DataManager.instance.controller.AddNewItem(items);
        information += "获得来自热心人士的资助";
    }

    void BadRun()
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        //有概率向老人索取报酬，老人可能会付出财富值或被迫捐出包里的道具
        if(Random.Range(0,100)>random)
        {
            if(Random.Range(0,2)>1)
            {
                DataManager.instance.controller.ItemsPackage.RemoveAt(0);
                PackageManager.RefreshItem();
                information += "被迫捐出包里的道具";
            }
            else
            {
                DataManager.instance.controller.Gold -= price;
                //会给老人劣质道具，使用后具有正常的效果，但是有概率会产生病症——中毒
                DataManager.instance.controller.AddNewItem(items);
                information += "被迫“自愿”购买物品";
            }
        }
        //降低老人心情值
        DataManager.instance.controller.ChangeBP(-price / 2);
        information += "，心情变差";
    }
}