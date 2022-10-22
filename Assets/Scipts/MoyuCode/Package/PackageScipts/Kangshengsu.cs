using Dmld;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kangshengsu : ItemOnDrag
{
    public override void ItemOnRun()
    {
        /*（提升下一次对抗病魔时不被感染的成功率的语句）*/
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
