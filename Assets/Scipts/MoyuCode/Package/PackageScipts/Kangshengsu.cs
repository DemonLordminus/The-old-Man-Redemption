using Dmld;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kangshengsu : ItemOnDrag
{
    public override void ItemOnRun()
    {
        /*��������һ�ζԿ���ħʱ������Ⱦ�ĳɹ��ʵ���䣩*/
        playerController.debuffs[14].isEnable = true;
        foreach (DebuffClass debuff in playerController.debuffs)
        {
            if (debuff.keepTime > 0)
            {
                debuff.keepTime -= kangshengsu;
            }
        }
        kangshengsu *= 0.75f;
    }
}
