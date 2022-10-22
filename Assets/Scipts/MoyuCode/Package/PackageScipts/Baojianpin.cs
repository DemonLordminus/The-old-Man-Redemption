using Dmld;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baojianpin : ItemOnDrag
{
    public override void ItemOnRun()
    {
        playerController.ChangeHealth(10);
        playerController.ChangeSp(10);
    }
}
