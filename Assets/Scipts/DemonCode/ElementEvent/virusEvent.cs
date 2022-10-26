using Dmld;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class virusEvent : eventElmentFather
{
    [SerializeField]
    public GetItem[] items;
    //public bool BadOrGood;
    public int inlit;
    public int random1;
    public float escapeF;
    public override void getEventPerform()
    {
        if (!isGood)
        {
            information += "老人遭遇了病魔";
            BadRun();
            DataManager.instance.eventFinishing.Add(information);
            Destroy(gameObject.transform.parent.gameObject);
            Destroy(gameObject);
            return;
        }
        if (!OnLaw("病魔是坏的") || !OnAct("避开病魔"))
        {
            information += "老人获得了疫苗";
            GoodRun();
            DataManager.instance.eventFinishing.Add(information);
            Destroy(gameObject.transform.parent.gameObject);
            Destroy(gameObject);
        }
        else
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
    void GoodRun()
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        //同中药
        if (Random.Range(1, 7) < inlit)
        {
            DataManager.instance.controller.ChangeHealth(Random.Range(0, 11));
        }
        if (Random.Range(1, 7) < inlit)
        {
            DataManager.instance.controller.ChangeSp(Random.Range(0, 11));
        }
        if (Random.Range(1, 7) < inlit)
        {
            DataManager.instance.controller.ChangeBP(Random.Range(0, 11));
        }
        information += "，各项属性回复";
    }

    void BadRun()
    {
        DataManager.instance.controller.RandomDebuff();
        bool escape = Random.Range(0, escapeF) > 5;
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        //老人在遭遇病魔时，会手持桃木剑与其战斗。（抗争具体化）
        //数值判定
        //在战斗判定时，会检测老人的规律与数值，判定结果
        //病魔无法规避，遇上强制触发，但是规避的尝试会带来优势
        //根据老人健康与否和规律合理与否，将判断是否患病，越健康越规律，则患病概率越低
        inlit = (int)DataManager.instance.controller.CurrentBp / (int)DataManager.instance.controller.MaxBp * 80 + DataManager.instance.lawOrActLists.HealthyLawLists.Count * 5;
        if (escape)
        {
            //增益;
            inlit += 5;
            information += "，尝试逃脱，虽然失败，但获得了一些优势";
        }
        random1 = Random.Range(0, inlit);
        if (random1 < random)
        {
            DataManager.instance.controller.ChangeHealth(-20);
            DataManager.instance.debuffName.AddRange(debuffClasses);
            information += "，感染了病症";
        }
        else if (random1 < random+10 )
        {
            DataManager.instance.controller.ChangeHealth(-10);
            information += "，所幸没有患病，但健康值有所下降";
        }
        else
        {
            information += "，幸运的是无事发生";
            return;
        }

    }
}
