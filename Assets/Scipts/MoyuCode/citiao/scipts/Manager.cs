using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
//������UI������
public class Manager : MonoBehaviour
{
    //����һ�����еľ�̬�ֶ�
    static Manager instance;
    public Inventory inventory;
    public GameObject Grid;
    public citiao citiaoPrefab;
    void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
    }

    public static void CreateNewcitiao(ScrObjcitiao getcitiao)
    {
        citiao newcitiao = Instantiate(instance.citiaoPrefab, instance.Grid.transform.position, Quaternion.identity);
        newcitiao.gameObject.transform.SetParent(instance.Grid.transform);
        newcitiao.citiaoScrObj = getcitiao;
        newcitiao.textShow.text = getcitiao.Content;
    }

    private void FixedUpdate()
    {
        //ʹ�������������֮�����ұ�����
        //if (Grid.transform.childCount == 4)
        //{
        //    Grid = GameObject.FindGameObjectWithTag("Grid1");
        //}
    }
}
