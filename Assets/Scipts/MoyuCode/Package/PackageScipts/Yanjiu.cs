using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yanjiu : ItemOnDrag
{
    public override void ItemOnRun()
    {
        playerController.ChangeHealth(-5);
        playerController.ChangeBP(10);
        /*������̾Ƴ������ϰ�ߵ���䣩*/
    }
}
