using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MailboxEvent : eventElmentFather
{
    [SerializeField]
    public GetItem[] Gooditems1,Gooditems2;
    public GetItem[] Baditems1,Baditems2;

    //public bool BadOrGood;
    public int price;
    //public bool ishave;
    public override void getEventPerform()
    {

        if (!OnLaw("�����ǻ���") || !OnAct("�ܿ�����"))
        {
            if (isGood)
            {
                information += "��������������";
                GoodRun();
                OnPresent();
            }
            else
            {
                information += "���������˺�������";
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
        //�����ѲƸ�ֵ
        //���˻Ὣ������һ���ʾ�֮����¼���¼д���ż��������
        //���ṩ�м���ֽ���и����ṩ�߼���ֽ
        if (Random.Range(0,100)>random)
        {
            DataManager.instance.controller.AddNewItem(Gooditems1);
        }
        else
        {
            DataManager.instance.controller.AddNewItem(Gooditems2);
        }
        //if(ishave)
        //{
        //    DataManager.instance.controller.Isrun = true;
        //    ishave = false;
        //}
        information += "�������һЩ��ֽ";
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
            { DataManager.instance.controller.AddNewItem(Baditems1);}
            else
            { DataManager.instance.controller.AddNewItem(Baditems2);}
            DataManager.instance.controller.Gold -= price;
        }
        information += "������һЩ��Ǯ��������ֽ";
    }
    void OnPresent()
    {
        foreach(string eventInformation in DataManager.instance.eventFinishing)
        {
            DataManager.instance.endFinishin.Add(eventInformation);
            DataManager.instance.allEvent.transform.GetChild(0).gameObject.GetComponent<Text>().text += "\n"+eventInformation;
        }
        try
        {
            if (DataManager.instance.allEvent.transform.GetChild(0).gameObject.GetComponent<Text>().text != "")
            {
                DataManager.instance.allEvent.SetActive(true);
                DataManager.instance.controller.isPalse = true;
            }
        }
        catch
        { }
        DataManager.instance.eventFinishing.Clear();
    }
}
