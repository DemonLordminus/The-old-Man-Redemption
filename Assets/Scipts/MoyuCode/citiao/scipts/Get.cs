using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//获取词条
public class Get: MonoBehaviour
{
    //获取getciao和inventory这个类的属性，并从unity界面选择
    public Getcitiao getcitiao;
    public Inventory Inventory;
    public bool ifUse;
    //添加词条
    public void AddNewIten()
    {
        if(!Inventory.getcitiaos.Contains(getcitiao))
        { 
            Inventory.getcitiaos.Add(getcitiao);
            Manager.CreateNewcitiao(getcitiao);
        }
    }

    protected void OnMouseDown()
    {
        ifUse =GameObject.Find("Ink").GetComponent<MouseManager>().ifUse;
        if (ifUse)
        {
            AddNewIten();
            GameObject.Find("Ink").GetComponent<MouseManager>().ifUse=false;
        }
    }
    //开局清空
    private void Start()
    {
        Inventory.getcitiaos.Clear();
    }

}
