using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swyl : ItemOnDrag
{
    public override void ItemOnRun()
    {
        playerController.ChangeSp(swyl);
    }
}
