using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TraggerManager : MonoBehaviour
{
    public GameObject tragger;
    public bool Open()
    {
        if(tragger.activeSelf==true)
        { return false; }
        //ʹ�������ڴ�����
        tragger.SetActive(true);
        //���ô�����������
        for (int i = 0; i < tragger.transform.GetChild(i).childCount-1; i++)
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
        return  true;
    }
}
