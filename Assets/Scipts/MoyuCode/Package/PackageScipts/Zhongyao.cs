using Dmld;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zhongyao : ItemOnDrag
{
    public override void ItemOnRun()
    {
        foreach (DebuffClass debuff in playerController.debuffs)//减少debuff持续时间
        {
            if (debuff.keepTime > 0 && debuff.DebuffOrder < 10)
            {
                count1 = 1;
                debuff.keepTime -= 5;
            }
        }
        if (playerController.CurrentHealthy < playerController.MaxHealthy * 0.75)//加血
        {
            playerController.ChangeHealth(20); count1 += 1;
        }
        if (playerController.CurrentBp < playerController.MaxBp * 0.75)//加体力
        {
            playerController.ChangeBP(20); count1 += 1;
        }
        if (playerController.CurrentBp < playerController.MaxBp * 0.75)//加幸福度
        {
            playerController.debuffs[10].keepTime = 10;
            playerController.debuffs[10].isEnable = true;
            count1 += 1;
        }
        playerController.MaxHealthy += (4 - count1) * 5;//加血量上限
        /*（阻挡病魔效果的语句）*/
    }
}
