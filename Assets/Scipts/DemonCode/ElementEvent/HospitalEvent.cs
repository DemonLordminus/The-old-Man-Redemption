using Dmld;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HospitalEvent : eventElmentFather
{
    [SerializeField]
    public GetItem[] items;
    //public bool BadOrGood;
    public int price;
    public override void getEventPerform()
    {

        if (!OnLaw("ҽԺ�ǻ���") || !OnAct("�ܿ�ҽԺ"))
        {
            if (isGood)
            {
                information += "����������ҽԺ";
                GoodRun();
            }
            else
            {
                information += "���������˺���ҽԺ";
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
        //�����¼���Ҫһ���ĲƸ�ֵ����ʱ��С���ʳ�������Ԯ��֮�����ҽ�Ʒ��¼�
        if (Random.Range(0,100) > random)
        {
            DataManager.instance.controller.AddNewItem(items);
            DataManager.instance.controller.ChangeHealth(Random.Range(10, 21));
            information += "���õ�����Ԯ�������ҽ�Ʒѣ��������";
            //�ɹ������¼�����������в�֢���и��ʻ��á�ҽ��������ҽ�������ṩ�����ڶԿ���֢��������ɴ�����ͬʱ�����¼���¼�����Կ�����ĳ�ֲ�֢��Ҫʲôҩ�
            if (DataManager.instance.debuffName != null && Random.Range(0, 2) == 1)
            {
                //DataManager.instance.lawOrActLists.lawlists.Add();
            }
            return;
        }
        if (DataManager.instance.controller.Gold > price)
        {
            DataManager.instance.controller.AddNewItem(items);
            DataManager.instance.controller.Gold -= price*items.Length;
            DataManager.instance.controller.ChangeHealth(Random.Range(10, 21));
            information += "";
            return;
        }
        //�Ƹ�ֵ������δ������ã���ֱ���ж�ʧ�ܲ��˳���ͬʱ�����Ҹ��ȡ�
        information += "�����Ƹ�ֵ���㣬������";
        DataManager.instance.controller.ChangeBP(-10);
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
        //��Ҫ��������ĲƸ�ֵ���Ҵ�ʱ���ܵ��²Ƹ�ֵΪ������Ƿծ��
        else if (DataManager.instance.controller.Gold > price)
        {
            DataManager.instance.controller.AddNewItem(items);
            DataManager.instance.controller.Gold -= 2 * price*items.Length;
            //�ɹ������¼������ʻָ����������ȣ�С���ʼ��ٽ�����
            if (Random.Range(0,100)< random)
            {
                DataManager.instance.controller.ChangeHealth(10);
            }
            else
            {
                DataManager.instance.controller.ChangeHealth(-10);
            }
            information += "����������ļ۸����˵���";
            //��С����ʹ�ò�֢�ĳ���ֵ����
            if (Random.Range(0,100)>10+random)
            {
                foreach (DebuffClass debuff in DataManager.instance.debuffName)
                {
                    debuff.keepTime += 10;
                }
                information += "����Ϊ����ʧ�䣬���²�֢����ֵ����";
            }
            //С������������������õ��������
            if (Random.Range(1, 7) < 3)
            {
                information += "��Ϊ����ʧ�䣬���˲���Ը�Ᵽ��һЩ��õ��������";
            }
            return;
        }
        DataManager.instance.controller.ChangeBP(-10);
    }
}
