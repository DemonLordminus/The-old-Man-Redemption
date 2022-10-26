using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
//������UI������
public class Manager : MonoBehaviour
{
    //����һ�����еľ�̬�ֶ�
    public static Manager instance;
    public Inventory inventory;
    public GameObject Grid;
    public citiao citiaoPrefab;
    public List<ScrObjcitiao> citiaoScrList;
    public Transform citiaoPos;
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
        Vector3 randomPos = new Vector3(UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(-10, 10), 0);
        newcitiao.gameObject.transform.position = instance.citiaoPos.position+randomPos;
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
