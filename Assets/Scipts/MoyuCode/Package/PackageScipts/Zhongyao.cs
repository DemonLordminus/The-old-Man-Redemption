using Dmld;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zhongyao : ItemOnDrag
{
    public override void ItemOnRun()
    {
        foreach (DebuffClass debuff in playerController.debuffs)//����debuff����ʱ��
        {
            if (debuff.keepTime > 0 && debuff.DebuffOrder < 10)
            {
                count1 = 1;
                debuff.keepTime -= 5;
            }
        }
        if (playerController.CurrentHealthy < playerController.MaxHealthy * 0.75)//��Ѫ
        {
            playerController.ChangeHealth(20); count1 += 1;
        }
        if (playerController.CurrentBp < playerController.MaxBp * 0.75)//������
        {
            playerController.ChangeBP(20); count1 += 1;
        }
        if (playerController.CurrentBp < playerController.MaxBp * 0.75)//���Ҹ���
        {
            playerController.debuffs[10].keepTime = 10;
            playerController.debuffs[10].isEnable = true;
            count1 += 1;
        }
        playerController.MaxHealthy += (4 - count1) * 5;//��Ѫ������
        /*���赲��ħЧ������䣩*/
    }
}
