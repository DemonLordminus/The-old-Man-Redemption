using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuji : ItemOnDrag
{
    public override void ItemOnRun()
    {
        playerController.ChangeBP(10);
        /*������ʶ�ƺ���Ԫ�ص���䣩*/
        playerController.debuffs[13].isEnable = true;
    }
}
