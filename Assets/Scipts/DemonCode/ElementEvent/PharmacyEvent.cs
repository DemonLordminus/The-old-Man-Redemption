using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PharmacyEvent : eventElmentFather
{
    [SerializeField]
    public GetItem[] items;
    public bool isRun;
    public override void getEventPerform()
    {
        OnLaw();
        OnAct();
        if (!isRun)
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            DataManager.instance.controller.AddNewItem(items);
            DataManager.instance.controller.Gold-=50;
        }
        else
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
    public override void OnLaw()
    {
        citiaoClassesLaw = DataManager.instance.lawOrActLists.CitiaoInlawlists.ToArray();
        for (int i = 0; i < DataManager.instance.lawOrActLists.LawNum; i += 3)
        {
            if (citiaoClassesLaw[i].CitiaoName + citiaoClassesLaw[i + 1].CitiaoName + citiaoClassesLaw[i + 2].CitiaoName == "Ò©µê£¨»µµÄ£©ÊÇ»µµÄ")
            {
                isRun = true;
            }
        }
    }
    public override void OnAct()
    {
        citiaoClassesAct =DataManager.instance.lawOrActLists.CitiaoInActLists.ToArray();
        for (int i = 0; i < LawNum; i += 2)
        {
            if (citiaoClassesAct[i].CitiaoName + citiaoClassesAct[i + 1].CitiaoName== "±Ü¿ªÒ©µê£¨±Ü¿ª£©")
            {
                isRun = true;
                DataManager.instance.lawOrActLists.RemoveAct(i);
            }
        }
    }
}
