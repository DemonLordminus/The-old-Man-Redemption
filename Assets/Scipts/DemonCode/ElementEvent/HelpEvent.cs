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

        if (!OnLaw("Ԯ�����ǻ���") || !OnAct("�ܿ�Ԯ����"))
        {
            if (isGood)
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
        //��ѣ��ṩ����ʳƷ����־��ҩ��ȵ���
        //������˱�������Ʒ�࣬�򲻻���ȡ
        if (DataManager.instance.package.Items.Count > inlit)
        {
            //������˱�������Ʒ��������ֵ�ͣ�������������ķ�ҩƷ��Ʒ���������������ֵ
            if (DataManager.instance.controller.CurrentBp < inlit)
            {
                DataManager.instance.package.Items.RemoveAt(Random.Range(0, DataManager.instance.package.Items.Count));
                DataManager.instance.controller.CurrentBp += upBp;
            }
            return;
        }
        DataManager.instance.controller.AddNewItem(items);
    }

    void BadRun()
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        //�и�����������ȡ���꣬���˿��ܻḶ���Ƹ�ֵ���Ⱦ������ĵ���
        if(Random.Range(0,100)<random)
        {
            if(Random.Range(0,2)>1)
            {
                DataManager.instance.package.Items.RemoveAt(0);
                PackageManager.RefreshItem();
            }
            else
            {
                DataManager.instance.controller.Gold -= price;
            }
        }
        //������������ֵ
        DataManager.instance.controller.ChangeBP(-price / 2);
        //����������ʵ��ߣ�ʹ�ú����������Ч���������и��ʻ������֢�����ж�
        DataManager.instance.controller.AddNewItem(items);
    }
}