using Dmld;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nlyl : ItemOnDrag
{
    public override void ItemOnRun()
    {
        playerController.nlylcot += 1;
        playerController.debuffs[11].isEnable = true;
        playerController.debuffs[11].keepTime = 10;
    }
}
