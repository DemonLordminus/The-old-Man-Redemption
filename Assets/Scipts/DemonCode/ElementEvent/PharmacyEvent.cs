using Dmld;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;

public class PharmacyEvent : eventElmentFather
{
    [SerializeField]
    public GetItem[] items;
    //public bool BadOrGood;
    public int price;
    public int inlit;
    public override void getEventPerform()
    {

        if (!OnLaw("ҩ���ǻ���") || !OnAct("�ܿ�ҩ��"))
        {
            if (isGood)
            {
                information += "����������ҩ��";
                GoodRun();
            }
            else
            {
                information += "���������˺���ҩ��";
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
        //���вƸ�ֵ������һ���Ƹ�ֵ�������ҩƷ
        if (DataManager.instance.controller.Gold>50)
        {
            foreach(var item in items)
            {
                if (DataManager.instance.controller.ItemsPackage.Count < inlit)
                {
                    DataManager.instance.controller.AddNewItem(item);
                    DataManager.instance.controller.Gold -= price;
                }
                else
                {
                    break;
                }
            }
            information += "��������һЩҩƷ";
        }
        else
        {
            DataManager.instance.controller.ChangeBP(-10);
            information += "�������������������";
        }
    }

    void BadRun()
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        //����Ƹ�ֵ�㹻������������и����������������˳����ⱻ��
        if (DataManager.instance.controller.Gold > 2 * price && Random.Range(0, 100) > random)
        {
            information += "�������������ʶ�ƣ���δ����";
            return;
        }
        //�۸�ܸߣ����ĵĲƸ�ֵ�ܶ�
        else 
        {
            foreach(var item in items)
            {
                if (DataManager.instance.controller.ItemsPackage.Count < inlit)
                {
                    DataManager.instance.controller.AddNewItem(item);
                    DataManager.instance.controller.Gold -= 2*price;
                }
                else
                {
                    break;
                }
            }
        }
        DataManager.instance.controller.ChangeBP(-10);
        information += "�����Ѹ��ߵļ۸���ҩƷ���������";
    }
}
