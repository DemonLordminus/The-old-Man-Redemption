using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailboxEvent : eventElmentFather
{
    [SerializeField]
    public GetItem[] items;
    public bool BadOrGood;
    public int price;
    public bool ishave;
    public override void getEventPerform()
    {

        if (!OnLaw("�����ǻ���") || !OnAct("�ܿ�����"))
        {
            if (BadOrGood && ishave)
            {
                GoodRun();
            }
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
    }

    void BadRun()
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        //��Ҫ�Ƹ�ֵ���ṩ����
        //���˵��ʼ��и��ʳ����𻵣�����һ�����һ����ʧ
        if (DataManager.instance.controller.Gold > price)
        {
            //���ṩ�ͼ���ֽ���и����ṩ�м���ֽ
            if (Random.Range(0,100)>random)
            { DataManager.instance.controller.AddNewItem(items);}
            else
            { DataManager.instance.controller.AddNewItem(items);}
            DataManager.instance.controller.Gold -= price;
        }
    }
}
