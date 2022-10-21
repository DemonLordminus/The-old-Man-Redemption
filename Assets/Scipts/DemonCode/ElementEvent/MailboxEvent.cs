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

        if (OnLaw("�����ǻ���") || OnAct("�ܿ�����"))
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
        //�����ѲƸ�ֵ
        //���˻Ὣ������һ���ʾ�֮����¼���¼д���ż��������
        //���ṩ�м���ֽ���и����ṩ�߼���ֽ
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
        //��Ҫ�Ƹ�ֵ���ṩ����
        //���˵��ʼ��и��ʳ����𻵣�����һ�����һ����ʧ
        if (DataManager.instance.controller.Gold > price)
        {
            //���ṩ�ͼ���ֽ���и����ṩ�м���ֽ
            if (Random.Range(1,7)>4)
            { DataManager.instance.controller.AddNewItem(items);}
            else
            { DataManager.instance.controller.AddNewItem(items);}
            DataManager.instance.controller.Gold -= price;
        }
    }
}
