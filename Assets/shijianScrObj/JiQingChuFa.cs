using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JiQingChuFa : MonoBehaviour
{
    public Shijian Shijian;
    /*private void Awake()
    {
        ShijianR.Shijian = DataManager.instance.shijianList.shijianlist[Random.Range(0, DataManager.instance.shijianList.shijianlist.Count)];*//*
        if (!ShijianR.Shijian.isNormal)
        {
            WhatScipt();
        }*//*
    }*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        DataManager.instance.JuQingFinishin.Add(Shijian.eventname+"\n"+ "\t\t"+Shijian.eventinfomation);
        DataManager.instance.allEvent.transform.GetChild(0).gameObject.GetComponent<Text>().text = DataManager.instance.JuQingFinishin[DataManager.instance.JuQingFinishin.Count - 1];
        DataManager.instance.allEvent.SetActive(true);
        DataManager.instance.controller.isPalse = true;
        Destroy(gameObject);
    }
}
