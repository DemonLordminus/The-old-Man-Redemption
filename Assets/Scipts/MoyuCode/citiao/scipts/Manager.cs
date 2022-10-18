using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
//词条在UI中生成
public class Manager : MonoBehaviour
{
    //声明一个特有的静态字段
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
        //在在网格的位置生成一个词条预制件
        citiao newcitiao = Instantiate(instance.citiaoPrefab, instance.Grid.transform.position, Quaternion.identity);
        newcitiao.gameObject.transform.SetParent(instance.Grid.transform);
        newcitiao.citiaoScrObj = getcitiao;
        int r = UnityEngine.Random.Range(0, getcitiao.Image.Length);
        newcitiao.image = getcitiao.Image[r];
    }

    private void FixedUpdate()
    {
        //使词条在左边满了之后在右边生成
        //if (Grid.transform.childCount == 4)
        //{
        //    Grid = GameObject.FindGameObjectWithTag("Grid1");
        //}
    }
}
