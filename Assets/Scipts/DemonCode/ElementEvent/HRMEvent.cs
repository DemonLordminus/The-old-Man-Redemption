using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HRMEvent : eventElmentFather
{
    [SerializeField]
    public GetItem[] items;
    public bool BadOrGood;
    public int inlit;
    public int random;
    public float escapeF;
    public override void getEventPerform()
    {

        if (OnLaw("人才市场是坏的") || OnAct("避开人才市场"))
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
        //只有在体力值高于一定值时才可以换取金钱，否则少量降低幸福度（年老气衰而自卑)
        //消耗一个随机范围的体力值，消耗的体力越多获得的金钱越多
        if (DataManager.instance.controller.CurrentSp > inlit)
        {
            random=Random.Range(0, 20);
            DataManager.instance.controller.ChangeSp(-random);
            DataManager.instance.controller.Gold+=random;
            return;
        }
    }

    void BadRun()
    {
        bool escape = Random.Range(0, escapeF) > 5;
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        //老人有概率识破并跑路
        if (escape)
        {
            return;
        }
        //体力值门槛极低，基本只要没跑路就会被压榨
        //如果体力值高于一定值，则随机消耗大量体力，且获得的金钱极少（黑中介）
        else if (DataManager.instance.controller.CurrentSp > 0.2 * inlit)
        {
            random= Random.Range(40, 60);
            DataManager.instance.controller.Gold -= (float)0.2 * random;
            DataManager.instance.controller.ChangeSp(-random);
        }
        //如果体力值低于一定值，则会少量消耗体力值，但是同时会付出财富值（违约惩罚）
        else
        {
            random = Random.Range(0, 20);
            DataManager.instance.controller.ChangeSp(-random);
            DataManager.instance.controller.Gold-=2*random;
        }
        if(Random.Range(1,7)<2)
        {
            //有一定概率在过程中患病症
            DataManager.instance.debuffName.AddRange(debuffClasses);
        }
    }
}
