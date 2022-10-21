using Dmld;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HospitalEvent : eventElmentFather
{
    [SerializeField]
    public GetItem[] items;
    public bool BadOrGood;
    public int price;
    public float escapeF;
    public override void getEventPerform()
    {

        if (OnLaw("医院是坏的") || OnAct("避开医院"))
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
        //触发事件需要一定的财富值，此时会小概率出现政府援助之类的免医疗费事件
        if (Random.Range(1, 7) > 5)
        {
            DataManager.instance.controller.AddNewItem(items);
            DataManager.instance.controller.ChangeHealth(Random.Range(10, 21));
            //成功触发事件后，如果身上有病症，有概率会获得“医嘱”。“医嘱”会提供有利于对抗病症的生活规律词条，同时会在事件记录里标出对抗自身某种病症需要什么药物。
            if (DataManager.instance.debuffName != null && Random.Range(0, 2) == 1)
            {
                //DataManager.instance.lawOrActLists.lawlists.Add();
            }
            return;
        }
        if (DataManager.instance.controller.Gold > price)
        {
            DataManager.instance.controller.AddNewItem(items);
            DataManager.instance.controller.Gold -= price;
            DataManager.instance.controller.ChangeHealth(Random.Range(10, 21));
            return;
        }
        //财富值不足且未免除费用，则直接判定失败并退出，同时降低幸福度。
        DataManager.instance.controller.ChangeBP(-10);
    }

    void BadRun()
    {
        bool escape = Random.Range(0, escapeF) < 5;
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        //如果财富值足够，进行随机，有概率老人自行醒悟，退出避免被坑
        if (DataManager.instance.controller.Gold > 2 * price && escape)
        {
            return;
        }
        //需要付出更多的财富值，且此时可能导致财富值为负数（欠债）
        else if (DataManager.instance.controller.Gold > price)
        {
            DataManager.instance.controller.AddNewItem(items);
            DataManager.instance.controller.Gold -= 2 * price;
            //成功触发事件后大概率恢复少量健康度，小概率减少健康度
            if (Random.Range(1, 7) < 5)
            {
                DataManager.instance.controller.ChangeHealth(10);
            }
            else
            {
                DataManager.instance.controller.ChangeHealth(-10);
            }
            //极小概率使得病症的持续值增加
            if (Random.Range(1, 7) < 2)
            {
                foreach (DebuffClass debuff in DataManager.instance.debuffName)
                {
                    debuff.keepTime += 10;
                }
            }
            //小概率清除老人身上良好的生活规律
            if (Random.Range(1, 7) < 3)
            {

            }
            return;
        }
        DataManager.instance.controller.ChangeBP(-10);
    }
}
