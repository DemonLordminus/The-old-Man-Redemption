using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yanyaoshui : ItemOnDrag
{
    public override void ItemOnRun()
    {
        virtualCamera.m_Lens.OrthographicSize = Mathf.Clamp(virtualCamera.m_Lens.OrthographicSize + 1, 2, 5);
        playerController.debuffs[15].isEnable = true;
        playerController.debuffs[15].keepTime = 10;
        playerController.debuffs[9].keepTime -= 5;
    }
}
