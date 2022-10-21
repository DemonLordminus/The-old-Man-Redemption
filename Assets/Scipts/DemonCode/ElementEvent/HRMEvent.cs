using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HRMEvent : eventElmentFather
{
    [SerializeField]
    public GetItem[] items;
    public bool BadOrGood;
    public int inlit;
    public int random;
    public float escapeF;
    public override void getEventPerform()
    {

        if (OnLaw("�˲��г��ǻ���") || OnAct("�ܿ��˲��г�"))
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
        //ֻ��������ֵ����һ��ֵʱ�ſ��Ի�ȡ��Ǯ���������������Ҹ��ȣ�������˥���Ա�)
        //����һ�������Χ������ֵ�����ĵ�����Խ���õĽ�ǮԽ��
        if (DataManager.instance.controller.CurrentSp > inlit)
        {
            random=Random.Range(0, 20);
            DataManager.instance.controller.ChangeSp(-random);
            DataManager.instance.controller.Gold+=random;
            return;
        }
    }

    void BadRun()
    {
        bool escape = Random.Range(0, escapeF) > 5;
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        //�����и���ʶ�Ʋ���·
        if (escape)
        {
            return;
        }
        //����ֵ�ż����ͣ�����ֻҪû��·�ͻᱻѹե
        //�������ֵ����һ��ֵ����������Ĵ����������һ�õĽ�Ǯ���٣����н飩
        else if (DataManager.instance.controller.CurrentSp > 0.2 * inlit)
        {
            random= Random.Range(40, 60);
            DataManager.instance.controller.Gold -= (float)0.2 * random;
            DataManager.instance.controller.ChangeSp(-random);
        }
        //�������ֵ����һ��ֵ�����������������ֵ������ͬʱ�Ḷ���Ƹ�ֵ��ΥԼ�ͷ���
        else
        {
            random = Random.Range(0, 20);
            DataManager.instance.controller.ChangeSp(-random);
            DataManager.instance.controller.Gold-=2*random;
        }
        if(Random.Range(1,7)<2)
        {
            //��һ�������ڹ����л���֢
            DataManager.instance.debuffName.AddRange(debuffClasses);
        }
    }
}
