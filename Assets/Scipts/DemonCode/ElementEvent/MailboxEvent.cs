using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MailboxEvent : eventElmentFather
{
    [SerializeField]
    public GetItem[] items;
    //public bool BadOrGood;
    public int price;
    public bool ishave;
    public override void getEventPerform()
    {

        if (!OnLaw("�����ǻ���") || !OnAct("�ܿ�����"))
        {
            OnPresent();
            if (isGood && ishave)
            {
                information += "��������������";
                GoodRun();
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
            { DataManager.instance.controller.AddNewItem(items);}
            else
            { DataManager.instance.controller.AddNewItem(items);}
            DataManager.instance.controller.Gold -= price;
        }
        information += "������һЩ��Ǯ������׾�ӵ���ֽ";
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
            DataManager.instance.allEvent.SetActive(true);
            DataManager.instance.controller.isPalse = true;
        }
        catch
        { }
        DataManager.instance.eventFinishing.Clear();
    }
}
