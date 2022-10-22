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
        mangmu = 9,
        zhongyao = 10,
        nlyl = 11,
        yangqiping = 12,
        shuji = 13,
        kangshengsu = 14,
        yanyaoshui = 15,
        zhitongyao = 16
    }

    [Serializable]
    public class DebuffClass//��֢��
    {
        public string debuffName;//��֢����������
        public int DebuffOrder;
        public DebuffType debuffType;//typeö������
        public float keepTime;//����ʱ��
        public bool isEnable;//Ч���Ƿ񴥷�
        public DebuffClass(string name,DebuffType type)
        { 
            this.debuffName = name;
            this.debuffType = type;
            this.keepTime = 120;
            DebuffOrder =(int)debuffType;
        }


        public DebuffClass(DebuffType type)
        {
            this.debuffType = type;
            DebuffOrder = (int)debuffType;
            autoRename();
            this.keepTime = 120;
        }
       public DebuffClass(int order)
        {
            DebuffOrder = order;
            this.debuffType = (DebuffType)order;
            autoRename();
            this.keepTime = 120;
        }
        //����Ϊ��ʱ���룬֮����Ҫ�ٸ�
        void autoRename()
        {
            switch (debuffType)
            { 
                case DebuffType.zhongdu: { debuffName = "�ж�"; break; }
                case DebuffType.fare: { debuffName = "����"; break; }
                case DebuffType.outufuxie: { debuffName = "Ż�¸�к"; break; }
                case DebuffType.fali: { debuffName = "����"; break; }
                case DebuffType.huxikunnan: { debuffName = "��������"; break; }
                case DebuffType.hunluan: { debuffName = "����"; break; }
                case DebuffType.jianwang: { debuffName = "����"; break; }
                case DebuffType.yiyu: { debuffName = "����"; break; }
                case DebuffType.jiaozao: { debuffName = "����"; break; }
                case DebuffType.mangmu: { debuffName = "äĿ"; break; }
                case DebuffType.zhongyao: { debuffName = "��ҩ"; break; }
                case DebuffType.nlyl: { debuffName = "��������"; break; }
                case DebuffType.yangqiping: { debuffName = "����ƿ"; break; }
                case DebuffType.shuji: { debuffName = "�鼮"; break; }
                case DebuffType.kangshengsu: { debuffName = "������"; break; }
                case DebuffType.yanyaoshui: { debuffName = "��ҩˮ"; break; }
                case DebuffType.zhitongyao: { debuffName = "ֹʹҩ"; break; }
            }
        }

    }
}
