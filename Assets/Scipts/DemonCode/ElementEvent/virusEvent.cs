using Dmld;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class virusEvent : eventElmentFather
{
    [SerializeField]
    public GetItem[] items;
    //public bool BadOrGood;
    public int inlit;
    public int random1;
    public float escapeF;
    public override void getEventPerform()
    {
        if (!isGood)
        {
            BadRun();
            Destroy(gameObject.transform.parent.gameObject);
            Destroy(gameObject);
            return;
        }
        if (!OnLaw("��ħ�ǻ���") || !OnAct("�ܿ���ħ"))
        {
            GoodRun();
            Destroy(gameObject.transform.parent.gameObject);
            Destroy(gameObject);
        }
        else
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
    void GoodRun()
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        //ͬ��ҩ
        if (Random.Range(1, 7) < inlit)
        {
            DataManager.instance.controller.ChangeHealth(Random.Range(0, 11));
        }
        if (Random.Range(1, 7) < inlit)
        {
            DataManager.instance.controller.ChangeSp(Random.Range(0, 11));
        }
        if (Random.Range(1, 7) < inlit)
        {
            DataManager.instance.controller.ChangeBP(Random.Range(0, 11));
        }
    }

    void BadRun()
    {
        bool escape = Random.Range(0, escapeF) > 5;
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        //������������ħʱ�����ֳ���ľ������ս�������������廯��
        //��ֵ�ж�
        //��ս���ж�ʱ���������˵Ĺ�������ֵ���ж����
        //��ħ�޷���ܣ�����ǿ�ƴ��������ǹ�ܵĳ��Ի��������
        if (escape)
        {
            //����;
        }
        //�������˽������͹��ɺ�����񣬽��ж��Ƿ񻼲���Խ����Խ���ɣ��򻼲�����Խ��
        inlit = (int)DataManager.instance.controller.CurrentBp / (int)DataManager.instance.controller.MaxBp * 60 + DataManager.instance.lawOrActLists.HealthyLawLists.Count * 5;
        random1 = Random.Range(0, inlit);
        if (random1 < random)
        {
            DataManager.instance.controller.ChangeHealth(-20);
            DataManager.instance.debuffName.AddRange(debuffClasses);
        }
        else if (random1 < random )
        {
            DataManager.instance.controller.ChangeHealth(-10);
        }
        else
        {
            return;
        }

    }
}
