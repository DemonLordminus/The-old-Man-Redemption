using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class TraggerManager : MonoBehaviour
{
    static TraggerManager instance;

    public Inventory inventory;
    public GameObject Grid;
    public citiao greenPrefab;
    public citiao medicinePrefab;
    void Awake()
    {
        if(instance == null)
            Destroy(this);
        instance = this;
    }

    public static void CreateNewcitiao(Getcitiao getcitiao)
    {
        if (getcitiao.Name == "green")
        {
            citiao newcitiao = Instantiate(instance.greenPrefab, instance.Grid.transform.position, Quaternion.identity);
            newcitiao.gameObject.transform.SetParent(instance.Grid.transform);
            newcitiao.citiaoName = getcitiao;
            newcitiao.image.sprite = getcitiao.Image;
        }
        if (getcitiao.Name == "medicine")
        {
            citiao newcitiao = Instantiate(instance.medicinePrefab, instance.Grid.transform.position, Quaternion.identity);
            newcitiao.gameObject.transform.SetParent(instance.Grid.transform);
            newcitiao.citiaoName = getcitiao;
            newcitiao.image.sprite = getcitiao.Image;
        }
    }

    private void FixedUpdate()
    {
        if (Grid.transform.childCount %3 ==0 )
        {
            Grid = GameObject.FindGameObjectWithTag("1");
        }
        else if(Grid.transform.childCount%3 == 1 )
        {
            Grid = GameObject.FindGameObjectWithTag("2");
        }
        else
        {
            Grid = GameObject.FindGameObjectWithTag("3");
        }
    }
}
