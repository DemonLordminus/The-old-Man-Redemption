using Dmld;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCMEvent : eventElmentFather
{
    [SerializeField]
    public GetItem[] items;
    public bool BadOrGood;
    public int price;
    public float escapeF;
    public override void getEventPerform()
    {

        if (OnLaw("��ҽԺ�ǻ���") || OnAct("�ܿ���ҽԺ"))
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
        //����һ���Ƹ�ֵ����Ի�õ�����ҩ
        if (DataManager.instance.controller.Gold > price)
        {
            DataManager.instance.controller.AddNewItem(items[0]);
            DataManager.instance.controller.Gold -= price;
            return;
        }
        //�Ƹ�ֵ����ʱ���и��ʻ��һ�ݲ�ҩ��Ϊ��������ҩ��Ч��Ϊ�ָ�����ֵ������ֵ
        else if (Random.Range(1,7)>4)
        {
            DataManager.instance.controller.AddNewItem(items[1]);
        }
        //���Ƹ�ֵ������δ��ò�ҩ��������������ֵ
        DataManager.instance.controller.ChangeBP(-10);
    }

    void BadRun()
    {
        bool escape = Random.Range(0,escapeF) > 5;
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        //����ʶ�ƿ�Ǯ����·�ĸ���Ĭ��Ϊ0
        if (escape)
        {
            return;
        }
        //��Ҫ�ĲƸ�ֵ��������ҽԺ�Թ�
        else if (DataManager.instance.controller.Gold > 1.2*price)
        {
            DataManager.instance.controller.AddNewItem(items[1]);
            DataManager.instance.controller.Gold -= (float)1.2 * price;
            DataManager.instance.controller.ChangeBP(5);
            return;
        }
        DataManager.instance.controller.ChangeBP(-10);
    }
}
