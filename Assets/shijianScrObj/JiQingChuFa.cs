using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JiQingChuFa : MonoBehaviour
{
    public Shijian Shijian;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        WhatShiJian();
        DataManager.instance.JuQingFinishin.Add(Shijian.eventname+"\n"+ "\t\t"+Shijian.eventinfomation);
        DataManager.instance.allEvent.transform.GetChild(0).gameObject.GetComponent<Text>().text = DataManager.instance.JuQingFinishin[DataManager.instance.JuQingFinishin.Count - 1];
        DataManager.instance.allEvent.SetActive(true);
        DataManager.instance.controller.isPalse = true;
        Destroy(gameObject);
    }
    void WhatShiJian()
    {
        switch(DataManager.instance.controller.loopNum)
        {
            case 0:Shijian = DataManager.instance.juqingList.shijianlist[0];break;
            case 1: Shijian = DataManager.instance.juqingList.shijianlist[1]; break;
            case 2: Shijian = DataManager.instance.juqingList.shijianlist[2]; break;
            case 3: Shijian = DataManager.instance.juqingList.shijianlist[3]; break;
            case 4: Shijian = DataManager.instance.juqingList.shijianlist[4]; break;
            case 5: Shijian = DataManager.instance.juqingList.shijianlist[5]; break;
            case 6: Shijian = DataManager.instance.juqingList.shijianlist[6]; break;
            case 7: Shijian = DataManager.instance.juqingList.shijianlist[7]; break;
        }
    }
}
