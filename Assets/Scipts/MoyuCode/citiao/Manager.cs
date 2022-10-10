using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
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

    public static void CreateNewcitiao(Getcitiao getcitiao)
    {
        citiao newcitiao = Instantiate(instance.citiaoPrefab, instance.Grid.transform.position, Quaternion.identity);
        newcitiao.gameObject.transform.SetParent(instance.Grid.transform);
        newcitiao.citiaoName = getcitiao;
        newcitiao.image.sprite = getcitiao.Image;
    }

    private void FixedUpdate()
    {
        if (Grid.transform.childCount == 4)
        {
            Grid = GameObject.FindGameObjectWithTag("Grid1");
        }
    }
}
