using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Xin : ItemOnDrag
{
    public int ChuOrZhongOrGao;
    public GameObject tragger;

    public override void ItemOnRun()
    {
        tragger = DataManager.instance.tragger;
        if (tragger.activeInHierarchy == true)
        {
            GetItem.Num += 1;
            return; 
        }
        //ʹ�������ڴ�����
        tragger.SetActive(true);
        //���ô�����������
        for (int i = 0; i < tragger.transform.GetChild(i).childCount - 1; i++)
        {
            for (int j = 0; j < tragger.transform.GetChild(i).childCount; j++)
            {
                try
                {
                    Destroy(tragger.transform.GetChild(i).GetChild(j).GetChild(0).gameObject);
                }
                catch
                { }
            }
        }
    }
}
