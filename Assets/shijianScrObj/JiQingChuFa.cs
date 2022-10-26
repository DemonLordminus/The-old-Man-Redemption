using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JiQingChuFa : MonoBehaviour
{
    public Shijian Shijian;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if (playerController != null)
        {
            WhatShiJian();
            DataManager.instance.JuQingFinishin.Add(Shijian.eventname + "\n" + "\t\t" + Shijian.eventinfomation);
            DataManager.instance.allEvent.transform.GetChild(0).gameObject.GetComponent<Text>().text = DataManager.instance.JuQingFinishin[DataManager.instance.JuQingFinishin.Count - 1];
            DataManager.instance.allEvent.SetActive(true);
            DataManager.instance.controller.isPalse = true;
            Destroy(gameObject);
        }
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
            case 8: Shijian = DataManager.instance.juqingList.shijianlist[8]; break;
            case 9: Shijian = DataManager.instance.juqingList.shijianlist[9]; break;
            case 10: Shijian = DataManager.instance.juqingList.shijianlist[10]; break;
            case 11: Shijian = DataManager.instance.juqingList.shijianlist[11]; break;
            case 12: Shijian = DataManager.instance.juqingList.shijianlist[12]; break;
            case 13: Shijian = DataManager.instance.juqingList.shijianlist[13]; break;
        }
    }
}
