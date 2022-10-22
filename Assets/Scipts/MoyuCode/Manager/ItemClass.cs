using Dmld;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�Ҵ������¸�һ��class�������citiao��������벻�ǲ��У����ǲ����� by Demon
public enum CitiaosType
{
    avoid = 0,
    bad = 1,
    cabinets_bad = 2,
    cabinets_avoid = 3,
    eat = 4,
    entry = 5,
    exercise = 6,
    good = 7,
    hospital_bad = 8,
    hospital_avoid = 9,
    HRM_bad = 10,
    HRM_avoid = 11,
    illness_bad = 12,
    illness_avoid = 13,
    pharmacy_bad = 14,
    pharmacy_avoid = 15,
    relax = 16,
    shi = 17,
    TCM_bad = 18,
    TCM_avoid = 19,
}
[Serializable]
public class ItemClass 
{
    public string CitiaoName;//��������������
    public int CitiaoOrder;
    public CitiaosType CitiaosType;//typeö������
    public bool isEnable;//Ч���Ƿ񴥷�
    public ItemClass(string name, CitiaosType type)
    {
        this.CitiaoName = name;
        this.CitiaosType = type;
        CitiaoOrder = (int)CitiaosType;
    }

    public ItemClass(CitiaosType type)
    {
        this.CitiaosType = type;
        CitiaoOrder = (int)CitiaosType;
        autoRename();
    }
    public ItemClass(int order)
    {
        CitiaoOrder = order;
        this.CitiaosType = (CitiaosType)order;
        autoRename();
    }
    //����Ϊ��ʱ���룬֮����Ҫ�ٸ�
    void autoRename()
    {
        switch (CitiaosType)
        {
            case CitiaosType.avoid: { CitiaoName = "�ܿ�"; break; }
            case CitiaosType.bad: { CitiaoName = "����"; break; }
            case CitiaosType.cabinets_avoid: { CitiaoName = "ҩ�񣨱ܿ���"; break; }
            case CitiaosType.cabinets_bad: { CitiaoName = "ҩ�񣨻��ģ�"; break; }
            case CitiaosType.eat: { CitiaoName = "�Զ���"; break; }

            case CitiaosType.entry: { CitiaoName = "����"; break; }
            case CitiaosType.exercise: { CitiaoName = "����"; break; }
            case CitiaosType.good: { CitiaoName = "�õ�"; break; }
            case CitiaosType.hospital_avoid: { CitiaoName = "ҽԺ���ܿ���"; break; }
            case CitiaosType.hospital_bad: { CitiaoName = "ҽԺ�����ģ�"; break; }

            case CitiaosType.HRM_avoid: { CitiaoName = "�˲��г����ܿ���"; break; }
            case CitiaosType.HRM_bad: { CitiaoName = "�˲��г������ģ�"; break; }
            case CitiaosType.illness_avoid: { CitiaoName = "��ħ���ܿ���"; break; }
            case CitiaosType.illness_bad: { CitiaoName = "��ħ�����ģ�"; break; }
            case CitiaosType.pharmacy_avoid: { CitiaoName = "ҩ�꣨�ܿ���"; break; }

            case CitiaosType.pharmacy_bad: { CitiaoName = "ҩ�꣨���ģ�"; break; }
            case CitiaosType.relax: { CitiaoName = "��Ϣ"; break; }
            case CitiaosType.shi: { CitiaoName = "��"; break; }
            case CitiaosType.TCM_avoid: { CitiaoName = "��ҽԺ���ܿ���"; break; }
            case CitiaosType.TCM_bad: { CitiaoName = "��ҽԺ�����ģ�"; break; }
        }
    }
}
