using Dmld;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HospitalEvent : eventElmentFather
{
    [SerializeField]
    public GetItem[] items;
    public bool BadOrGood;
    public int price;
    public float escapeF;
    public override void getEventPerform()
    {

        if (OnLaw("ҽԺ�ǻ���") || OnAct("�ܿ�ҽԺ"))
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
        //�����¼���Ҫһ���ĲƸ�ֵ����ʱ��С���ʳ�������Ԯ��֮�����ҽ�Ʒ��¼�
        if (Random.Range(1, 7) > 5)
        {
            DataManager.instance.controller.AddNewItem(items);
            DataManager.instance.controller.ChangeHealth(Random.Range(10, 21));
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
            DataManager.instance.controller.Gold -= price;
            DataManager.instance.controller.ChangeHealth(Random.Range(10, 21));
            return;
        }
        //�Ƹ�ֵ������δ������ã���ֱ���ж�ʧ�ܲ��˳���ͬʱ�����Ҹ��ȡ�
        DataManager.instance.controller.ChangeBP(-10);
    }

    void BadRun()
    {
        bool escape = Random.Range(0, escapeF) < 5;
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        //����Ƹ�ֵ�㹻������������и����������������˳����ⱻ��
        if (DataManager.instance.controller.Gold > 2 * price && escape)
        {
            return;
        }
        //��Ҫ��������ĲƸ�ֵ���Ҵ�ʱ���ܵ��²Ƹ�ֵΪ������Ƿծ��
        else if (DataManager.instance.controller.Gold > price)
        {
            DataManager.instance.controller.AddNewItem(items);
            DataManager.instance.controller.Gold -= 2 * price;
            //�ɹ������¼������ʻָ����������ȣ�С���ʼ��ٽ�����
            if (Random.Range(1, 7) < 5)
            {
                DataManager.instance.controller.ChangeHealth(10);
            }
            else
            {
                DataManager.instance.controller.ChangeHealth(-10);
            }
            //��С����ʹ�ò�֢�ĳ���ֵ����
            if (Random.Range(1, 7) < 2)
            {
                foreach (DebuffClass debuff in DataManager.instance.debuffName)
                {
                    debuff.keepTime += 10;
                }
            }
            //С������������������õ��������
            if (Random.Range(1, 7) < 3)
            {

            }
            return;
        }
        DataManager.instance.controller.ChangeBP(-10);
    }
}
