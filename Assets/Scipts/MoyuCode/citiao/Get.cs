using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get: MonoBehaviour
{


    public Getcitiao getcitiao;
    public Inventory Inventory;
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

    private void Start()
    {
        Inventory.getcitiaos.Clear();
    }

}
