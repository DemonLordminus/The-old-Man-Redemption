using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Chufa : MonoBehaviour
{
    public ShijianR ShijianR;
    #region 旧日
    /*public GameObject gameOver;
    float CurrentHealthy;
    float MaxHealthy = 100;
    float MaxSp;
    float CurrentSp = 100;
    float MaxBp;
    float CurrentBp = 100;
    bool isDie;
    int changehealth;
    int changebp;
    int changesp;
    public int maxevent;
    int num;
    public void ChangeHealth(int changehp)
    {
        CurrentHealthy = Mathf.Clamp(CurrentHealthy + changehp, 0, MaxHealthy);
        HealthyBarManager.Instance.SetValue(CurrentHealthy / (float)MaxHealthy);
        if (CurrentHealthy <= 0)
        {
            isDie = true;
            Time.timeScale = 0f;
            gameOver.SetActive(isDie);
        }
    }
    public void ChangeSp(int amount)
    {
        CurrentSp = Mathf.Clamp(CurrentSp + amount, 0, MaxSp);
        SpBarManager.Instance.SetValue(CurrentSp / (float)MaxSp);
    }

    public void ChangeBP(int amount)
    {
        CurrentBp = Mathf.Clamp(CurrentBp + amount, 0, MaxBp);
        BlissBarManager.Instance.SetValue(CurrentBp / (float)MaxBp);
    }*/
    #endregion
    //暂时不写
    private void Awake()
    {
        ShijianR.Shijian = DataManager.instance.shijianList.shijianlist[Random.Range(0, DataManager.instance.shijianList.shijianlist.Count)];/*
        if (!ShijianR.Shijian.isNormal)
        {
            WhatScipt();
        }*/
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if (playerController != null)
        {
            #region 旧日
            /* num = Random.Range(1, maxevent+1);
             changehealth = list.shijianlist[num].hpchange;
             changebp = list.shijianlist[num].bpchange;
             changesp = list.shijianlist[num].spchange;
             ChangeHealth(changehealth);
             ChangeBP(changebp);
             ChangeSp(changesp);
             Destroy(gameObject);*/
            #endregion
            try
            {
                OnRunNormal();
            }
            catch
            { }
            DataManager.instance.eventFinishing.Add(ShijianR.Shijian.eventinfomation);
            Destroy(gameObject);
        }
    }/*
    public virtual void OnRun()
    {

    }*/
    void OnRunNormal()
    {
        DataManager.instance.controller.ChangeHealth(ShijianR.Shijian.hpchange);
        DataManager.instance.controller.ChangeBP(ShijianR.Shijian.bpchange);
        DataManager.instance.controller.ChangeSp(ShijianR.Shijian.spchange);
        DataManager.instance.controller.Gold += ShijianR.Shijian.goldchange;
    }
}
