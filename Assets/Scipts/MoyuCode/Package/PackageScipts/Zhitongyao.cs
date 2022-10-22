using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zhitongyao : ItemOnDrag
{
    public override void ItemOnRun()
    {
        playerController.ChangeHealth(20);
        playerController.debuffs[16].isEnable = true;
        playerController.debuffs[16].keepTime = 10;
    }
}

