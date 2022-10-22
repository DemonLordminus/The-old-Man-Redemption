using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yanjiu : ItemOnDrag
{
    public override void ItemOnRun()
    {
        playerController.ChangeHealth(-5);
        playerController.ChangeBP(10);
        /*（获得烟酒成瘾生活习惯的语句）*/
    }
}
