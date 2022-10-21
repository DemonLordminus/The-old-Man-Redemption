using Dmld;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HlepEvent : eventElmentFather
{
    [SerializeField]
    public GetItem[] items;
    public bool BadOrGood;
    public int price;
    public int inlit;
    public int upBp;
    public override void getEventPerform()
    {

        if (OnLaw("Ԯ�����ǻ���") || OnAct("�ܿ�Ԯ����"))
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
        //��ѣ��ṩ����ʳƷ����־��ҩ��ȵ���
        //������˱�������Ʒ�࣬�򲻻���ȡ
        if(DataManager.instance.package.Items.Count>inlit)
        {
            //������˱�������Ʒ��������ֵ�ͣ�������������ķ�ҩƷ��Ʒ���������������ֵ
            if (DataManager.instance.controller.CurrentBp < inlit)
            {
                DataManager.instance.package.Items.RemoveAt(Random.Range(0, DataManager.instance.package.Items.Count));
                DataManager.instance.controller.CurrentBp += upBp;
            }
            return;
        }
        DataManager.instance.package.Items.AddRange(items);
    }

    void BadRun()
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        //�и�����������ȡ���꣬���˿��ܻḶ���Ƹ�ֵ���Ⱦ������ĵ���
        //������������ֵ
        DataManager.instance.controller.ChangeBP(-price/2);
        //����������ʵ��ߣ�ʹ�ú����������Ч���������и��ʻ������֢�����ж�
        if (Random.Range(1,7)>4)
        {
            DataManager.instance.controller.AddNewItem(items);
            if(Random.Range(1,7)>3)
            {
                DataManager.instance.debuffName.Add(debuffClasses[0]);
            }
        }
    }
}