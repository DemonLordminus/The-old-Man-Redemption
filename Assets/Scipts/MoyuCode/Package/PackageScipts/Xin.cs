using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xin : ItemOnDrag
{
    public override void ItemOnRun()
    {
        if (!traggerManager.GetComponent<TraggerManager>().Open())
        {
            GetItem.Num += 1;
        }
    }
}
