using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuji : ItemOnDrag
{
    public override void ItemOnRun()
    {
        playerController.ChangeBP(10);
        /*（增加识破黑心元素的语句）*/
        playerController.debuffs[13].isEnable = true;
    }
}
