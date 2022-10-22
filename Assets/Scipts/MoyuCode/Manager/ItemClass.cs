using Dmld;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//我打算重新搞一个class来做这个citiao，这个代码不是不行，但是不够好 by Demon
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
    public string CitiaoName;//词条的中文名字
    public int CitiaoOrder;
    public CitiaosType CitiaosType;//type枚举类型
    public bool isEnable;//效果是否触发
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
    //以下为临时代码，之后需要再改
    void autoRename()
    {
        switch (CitiaosType)
        {
            case CitiaosType.avoid: { CitiaoName = "避开"; break; }
            case CitiaosType.bad: { CitiaoName = "坏的"; break; }
            case CitiaosType.cabinets_avoid: { CitiaoName = "药柜（避开）"; break; }
            case CitiaosType.cabinets_bad: { CitiaoName = "药柜（坏的）"; break; }
            case CitiaosType.eat: { CitiaoName = "吃东西"; break; }

            case CitiaosType.entry: { CitiaoName = "进入"; break; }
            case CitiaosType.exercise: { CitiaoName = "锻炼"; break; }
            case CitiaosType.good: { CitiaoName = "好的"; break; }
            case CitiaosType.hospital_avoid: { CitiaoName = "医院（避开）"; break; }
            case CitiaosType.hospital_bad: { CitiaoName = "医院（坏的）"; break; }

            case CitiaosType.HRM_avoid: { CitiaoName = "人才市场（避开）"; break; }
            case CitiaosType.HRM_bad: { CitiaoName = "人才市场（坏的）"; break; }
            case CitiaosType.illness_avoid: { CitiaoName = "病魔（避开）"; break; }
            case CitiaosType.illness_bad: { CitiaoName = "病魔（坏的）"; break; }
            case CitiaosType.pharmacy_avoid: { CitiaoName = "药店（避开）"; break; }

            case CitiaosType.pharmacy_bad: { CitiaoName = "药店（坏的）"; break; }
            case CitiaosType.relax: { CitiaoName = "休息"; break; }
            case CitiaosType.shi: { CitiaoName = "是"; break; }
            case CitiaosType.TCM_avoid: { CitiaoName = "中医院（避开）"; break; }
            case CitiaosType.TCM_bad: { CitiaoName = "中医院（坏的）"; break; }
        }
    }
}
