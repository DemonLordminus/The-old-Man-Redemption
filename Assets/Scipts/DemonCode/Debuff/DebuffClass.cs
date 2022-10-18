using Dmld;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace Dmld
{
    public enum DebuffType
    {
        zhongdu = 0,
        fare = 1,
        fali = 2,
        outufuxie = 3,
        huxikunnan = 4,
        hunluan = 5,
        jianwang = 6,
        yiyu = 7,
        jiaozao = 8,
        mangmu = 9
    }

    [Serializable]
    public class DebuffClass//病症类
    {
        public string debuffName;//病症的中文名字
        public int DebuffOrder;
        public DebuffType debuffType;//type枚举类型
        public float keepTime;//持续时间
        public bool isEnable;//效果是否触发
        public DebuffClass(string name,DebuffType type)
        { 
            this.debuffName = name;
            this.debuffType = type;
            this.keepTime = 0;
            DebuffOrder =(int)debuffType;
        }


        public DebuffClass(DebuffType type)
        {
            this.debuffType = type;
            DebuffOrder = (int)debuffType;
            autoRename();
            this.keepTime = 0;
        }
       public DebuffClass(int order)
        {
            DebuffOrder = order;
            this.debuffType = (DebuffType)order;
            autoRename();
            this.keepTime = 0;
        }
        //以下为临时代码，之后需要再改
        void autoRename()
        {
            switch (debuffType)
            { 
                case DebuffType.zhongdu: { debuffName = "中毒"; break; }
                case DebuffType.fare: { debuffName = "发热"; break; }
                case DebuffType.outufuxie: { debuffName = "呕吐腹泻"; break; }
                case DebuffType.fali: { debuffName = "乏力"; break; }
                case DebuffType.huxikunnan: { debuffName = "呼吸困难"; break; }
                case DebuffType.hunluan: { debuffName = "混乱"; break; }
                case DebuffType.jianwang: { debuffName = "健忘"; break; }
                case DebuffType.yiyu: { debuffName = "抑郁"; break; }
                case DebuffType.jiaozao: { debuffName = "焦躁"; break; }
                case DebuffType.mangmu: { debuffName = "盲目"; break; }
            }
        }

    }
}
