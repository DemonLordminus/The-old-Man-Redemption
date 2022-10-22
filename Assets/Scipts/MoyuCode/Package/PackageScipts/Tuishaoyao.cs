using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuishaoyao : ItemOnDrag
{
    public override void ItemOnRun()
    {
        playerController.ChangeHealth(5);
        playerController.debuffs[1].keepTime -= 3;
    }
}
