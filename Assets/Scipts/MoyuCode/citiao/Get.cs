using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//��ȡ����
public class Get: MonoBehaviour
{
    //��ȡgetciao��inventory���������ԣ�����unity����ѡ��
    public Getcitiao getcitiao;
    public Inventory Inventory;
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
        AddNewIten();
    }
    //�������
    private void Start()
    {
        Inventory.getcitiaos.Clear();
    }

}
