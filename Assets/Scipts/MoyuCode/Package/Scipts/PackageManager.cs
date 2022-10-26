using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PackageManager : MonoBehaviour
{
    static PackageManager instance;

    //public Package Package;
    public List<GetItem> Package;
    public GameObject Grid;
    public Item itemPrefab;
    void Awake()
    {
        if(instance != null)
            Destroy(this);
        instance = this;
    }
    private void Start()
    {
        RefreshItem();
        Package = DataManager.instance.controller.ItemsPackage;
    }
    private void OnEnable()
    {
        RefreshItem();
    }
    public static void CreateNewItem(GetItem getItem)
    {
        Item newitem = Instantiate(instance.itemPrefab, instance.Grid.transform.position, Quaternion.identity);
        newitem.gameObject.transform.SetParent(instance.Grid.transform);
        newitem.itemname = getItem;
        newitem.Image.sprite=getItem.Image;
        newitem.num.text=getItem.Name+ getItem.Num.ToString();
    }

    public static void RefreshItem()
    {
        for(int i=0;i<instance.Grid.transform.childCount;i++)
        { 
            Destroy(instance.Grid.transform.GetChild(i).gameObject);
        }
        for(int i=0;i<instance.Package.Count;i++)
        {
            CreateNewItem(instance.Package[i]);
        }
    }
}
