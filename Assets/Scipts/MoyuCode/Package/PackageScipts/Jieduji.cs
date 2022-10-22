using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jieduji : ItemOnDrag
{
    public override void ItemOnRun()
    {
        playerController.ChangeHealth(5);
        playerController.debuffs[0].keepTime -= 10;
    }
}
