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
            information += "���������˲�ħ";
            BadRun();
            DataManager.instance.eventFinishing.Add(information);
            Destroy(gameObject.transform.parent.gameObject);
            Destroy(gameObject);
            return;
        }
        if (!OnLaw("��ħ�ǻ���") || !OnAct("�ܿ���ħ"))
        {
            information += "���˻��������";
            GoodRun();
            DataManager.instance.eventFinishing.Add(information);
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
        information += "���������Իظ�";
    }

    void BadRun()
    {
        DataManager.instance.controller.RandomDebuff();
        bool escape = Random.Range(0, escapeF) > 5;
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        //������������ħʱ�����ֳ���ľ������ս�������������廯��
        //��ֵ�ж�
        //��ս���ж�ʱ���������˵Ĺ�������ֵ���ж����
        //��ħ�޷���ܣ�����ǿ�ƴ��������ǹ�ܵĳ��Ի��������
        //�������˽������͹��ɺ�����񣬽��ж��Ƿ񻼲���Խ����Խ���ɣ��򻼲�����Խ��
        inlit = (int)DataManager.instance.controller.CurrentBp / (int)DataManager.instance.controller.MaxBp * 80 + DataManager.instance.lawOrActLists.HealthyLawLists.Count * 5;
        if (escape)
        {
            //����;
            inlit += 5;
            information += "���������ѣ���Ȼʧ�ܣ��������һЩ����";
        }
        random1 = Random.Range(0, inlit);
        if (random1 < random)
        {
            DataManager.instance.controller.ChangeHealth(-20);
            DataManager.instance.debuffName.AddRange(debuffClasses);
            information += "����Ⱦ�˲�֢";
        }
        else if (random1 < random+10 )
        {
            DataManager.instance.controller.ChangeHealth(-10);
            information += "������û�л�����������ֵ�����½�";
        }
        else
        {
            information += "�����˵������·���";
            return;
        }

    }
}
