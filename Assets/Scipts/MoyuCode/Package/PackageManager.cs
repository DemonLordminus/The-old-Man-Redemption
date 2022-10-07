using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class PackageManager : MonoBehaviour
{
    static PackageManager instance;

    public Package Package;
    public GameObject Grid;
    public Item itemPrefab;
    void Awake()
    {
        if(instance != null)
            Destroy(this);
        instance = this;
    }

    public static void CreateNewItem(GetItem getItem)
    {
        Item newitem = Instantiate(instance.itemPrefab, instance.Grid.transform.position, Quaternion.identity);
        newitem.gameObject.transform.SetParent(instance.Grid.transform);
        newitem.itemname = getItem;
        newitem.Image.sprite=getItem.Image;
        newitem.num.text=getItem.Num.ToString();
    }

    public static void RefreshItem()
    {
        for(int i=0;i<instance.Grid.transform.childCount;i++)
        {
            if (instance.Grid.transform.childCount == 0)
                break;
            Destroy(instance.Grid.transform.GetChild(0).gameObject);
        }
        for(int i=0;i<instance.Package.Items.Count;i++)
        {
            CreateNewItem(instance.Package.Items[i]);
        }
    }
}
