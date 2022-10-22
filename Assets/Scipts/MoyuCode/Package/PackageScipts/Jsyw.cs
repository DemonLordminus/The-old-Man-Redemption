using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jsyw : ItemOnDrag
{
    public override void ItemOnRun()
    {
        playerController.debuffs[5].keepTime -= 5;
        playerController.debuffs[7].keepTime -= 5;
        playerController.debuffs[8].keepTime -= 5;
        playerController.debuffs[6].keepTime -= 5;
        playerController.ChangeBP(10 * (Random.Range(0, 2)) * 2 - 1);
    }
}
