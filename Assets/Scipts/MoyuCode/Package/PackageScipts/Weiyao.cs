using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weiyao : ItemOnDrag
{
    public override void ItemOnRun()
    {
        playerController.debuffs[3].keepTime -= 3;
        playerController.ChangeHealth(5);
    }
}
