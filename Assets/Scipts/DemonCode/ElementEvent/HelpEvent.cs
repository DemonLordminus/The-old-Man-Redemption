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
    [Header("������ȡ�Ľ���")]
    public int inlit;
    public int upBp;
    public override void getEventPerform()
    {
        information = "";
        if (!OnLaw("Ԯ�����ǻ���") || !OnAct("�ܿ�Ԯ����"))
        {
            if (isGood)
            {
                information += "����������Ԯ������";
                GoodRun();
            }
            else
            {
                information += "���������˺���Ԯ������";
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
        //��ѣ��ṩ����ʳƷ����־��ҩ��ȵ���
        //������˱�������Ʒ�࣬�򲻻���ȡ
        if (DataManager.instance.controller.ItemsPackage.Count > inlit)
        {
            //������˱�������Ʒ��������ֵ�ͣ�������������ķ�ҩƷ��Ʒ���������������ֵ
            if (DataManager.instance.controller.CurrentBp < inlit)
            {
                DataManager.instance.controller.ItemsPackage.RemoveAt(Random.Range(0, DataManager.instance.controller.ItemsPackage.Count));
                DataManager.instance.controller.CurrentBp += upBp;
                information += "���Լ����������Ķ������˳�ȥ";
            }
            return;
        }
        DataManager.instance.controller.AddNewItem(items);
        information += "�������������ʿ������";
    }

    void BadRun()
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        //�и�����������ȡ���꣬���˿��ܻḶ���Ƹ�ֵ���Ⱦ������ĵ���
        if(Random.Range(0,100)>random)
        {
            if(Random.Range(0,2)>1)
            {
                DataManager.instance.controller.ItemsPackage.RemoveAt(0);
                PackageManager.RefreshItem();
                information += "���Ⱦ������ĵ���";
            }
            else
            {
                DataManager.instance.controller.Gold -= price;
                //����������ʵ��ߣ�ʹ�ú����������Ч���������и��ʻ������֢�����ж�
                DataManager.instance.controller.AddNewItem(items);
                information += "���ȡ���Ը��������Ʒ";
            }
        }
        //������������ֵ
        DataManager.instance.controller.ChangeBP(-price / 2);
        information += "��������";
    }
}