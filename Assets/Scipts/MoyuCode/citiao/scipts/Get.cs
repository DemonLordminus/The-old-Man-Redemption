using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//��ȡ����
public class Get: MonoBehaviour
{
    //��ȡgetciao��inventory���������ԣ�����unity����ѡ��
    public ScrObjcitiao getcitiao;
    public Inventory Inventory;
    public bool ifUse;
    //��Ӵ���
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
        //ifUse =GameObject.Find("Ink").GetComponent<InkManager>().ifUseInk;
        //if (ifUse)
        //{
        //    AddNewIten();
        //    GameObject.Find("Ink").GetComponent<InkManager>().ifUseInk =false;
        //}
    }
    //�������
    private void Start()
    {
        Inventory.getcitiaos.Clear();
    }

}
