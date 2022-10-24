using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HRMEvent : eventElmentFather
{
    [SerializeField]
    public GetItem[] items;
    //public bool BadOrGood;
    public int inlit;
    public int random1;
    public override void getEventPerform()
    {

        if (!OnLaw("�˲��г��ǻ���") || !OnAct("�ܿ��˲��г�"))
        {
            if (isGood)
            {
                information += "�����������˲��г�";
                GoodRun();
            }
            else
            {
                information += "���������˺����˲��г�";
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
        //ֻ��������ֵ����һ��ֵʱ�ſ��Ի�ȡ��Ǯ���������������Ҹ��ȣ�������˥���Ա�)
        //����һ�������Χ������ֵ�����ĵ�����Խ���õĽ�ǮԽ��
        if (DataManager.instance.controller.CurrentSp > inlit)
        {
            random1=Random.Range(0, 20);
            DataManager.instance.controller.ChangeSp(-random1);
            DataManager.instance.controller.Gold+=random1;
            information += "��ͨ��һ���������Ͷ�����˽�Ǯ";
            return;
        }
        information += "���������޷����£���������˥���Ա����Ҹ�ֵ�½�";
        DataManager.instance.controller.ChangeBP(-10);
    }

    void BadRun()
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        //�����и���ʶ�Ʋ���·
        if (Random.Range(0, 100) < random)
        {
            information += "�������������ʶ�ƣ���δ����";
            return;
        }
        //����ֵ�ż����ͣ�����ֻҪû��·�ͻᱻѹե
        //�������ֵ����һ��ֵ����������Ĵ����������һ�õĽ�Ǯ���٣����н飩
        else if (DataManager.instance.controller.CurrentSp > 0.2 * inlit)
        {
            random1= Random.Range(40, 60);
            DataManager.instance.controller.Gold += (float)0.2 * random1;
            DataManager.instance.controller.ChangeSp(-random1);
            information += "�������˺��н飬���Ĵ�������������Ǯ���ü���";
        }
        //�������ֵ����һ��ֵ�����������������ֵ������ͬʱ�Ḷ���Ƹ�ֵ��ΥԼ�ͷ���
        else
        {
            random1 = Random.Range(0, 20);
            DataManager.instance.controller.ChangeSp(-random1);
            DataManager.instance.controller.Gold-=2*random1;
            information += "����Ϊ�������㣬��ִ����ΥԼ�ͷ�����Ǯ����";
        }
        if(Random.Range(1,7)<2)
        {
            //��һ�������ڹ����л���֢
            DataManager.instance.debuffName.AddRange(debuffClasses);
            information += "����Ϊ���ۣ����һ���";
        }
    }
}
