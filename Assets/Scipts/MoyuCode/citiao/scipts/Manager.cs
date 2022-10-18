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
        Grid = GameObject.FindGameObjectWithTag("Grid");
    }

    public static void CreateNewcitiao(ScrObjcitiao getcitiao)
    {
        //���������λ������һ������Ԥ�Ƽ�
        citiao newcitiao = Instantiate(instance.citiaoPrefab, instance.Grid.transform.position, Quaternion.identity);
        newcitiao.gameObject.transform.SetParent(instance.Grid.transform);
        newcitiao.citiaoScrObj = getcitiao;
        int r = UnityEngine.Random.Range(0, getcitiao.Image.Length);
        newcitiao.image = getcitiao.Image[r];
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
