using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//获取词条
public class Get: MonoBehaviour
{
    //获取getciao和inventory这个类的属性，并从unity界面选择
    public Getcitiao getcitiao;
    public Inventory Inventory;
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
        AddNewIten();
    }
    //开局清空
    private void Start()
    {
        Inventory.getcitiaos.Clear();
    }

}
