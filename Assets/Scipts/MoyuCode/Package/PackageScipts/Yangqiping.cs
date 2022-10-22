using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yangqiping : ItemOnDrag
{
    public override void ItemOnRun()
    {
        playerController.debuffs[4].keepTime -= 3;
        playerController.debuffs[12].isEnable = true;
        playerController.debuffs[12].keepTime = 10;
        playerController.ChangeSp(20);
    }
}
