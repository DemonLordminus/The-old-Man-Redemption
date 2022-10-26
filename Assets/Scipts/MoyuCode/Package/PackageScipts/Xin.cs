using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xin : ItemOnDrag
{
    public int ChuOrZhongOrGao;
    public override void ItemOnRun()
    {
        if (!traggerManager.GetComponent<TraggerManager>().Open())
        {
            GetItem.Num += 1;
        }
        else
        {
            DataManager.instance.tragger.SetActive(true);
        }
    }
}
