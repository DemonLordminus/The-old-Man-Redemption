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
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < tragger.transform.GetChild(i).childCount; j++)
            {
                Destroy(tragger.transform.GetChild(i).GetChild(j).gameObject);
            }
        }
        return  true;
    }
}
