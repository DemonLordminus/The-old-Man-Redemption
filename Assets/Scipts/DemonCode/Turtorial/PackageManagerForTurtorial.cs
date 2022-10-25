using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
namespace tur
{
    public class PackageManagerForTurtorial : MonoBehaviour
    {
        static PackageManagerForTurtorial instance;

        //public Package Package;
        public List<GetItem> Package;
        public GameObject Grid;
        public Item itemPrefab;
        public PlayerControlForTurtorial playerTur;
        void Awake()
        {
            if (instance != null)
                Destroy(this);
            instance = this;
        }
        private void Start()
        {
            //Package =  playerTur.ItemsPackage;
        }
        private void OnEnable()
        {
            //RefreshItem();
        }

        public static void CreateNewItem(GetItem getItem)
        {
            Item newitem = Instantiate(instance.itemPrefab, instance.Grid.transform.position, Quaternion.identity);
            newitem.gameObject.transform.SetParent(instance.Grid.transform);
            newitem.itemname = getItem;
            newitem.Image.sprite = getItem.Image;
            newitem.num.text = getItem.Num.ToString();
        }

        public GetItem letter;
        public PackageManagerForTurtorial ins;
        [EditorButton]
        public void CreateLetter()
        {
            Item newitem = Instantiate(ins.itemPrefab, ins.Grid.transform.position, Quaternion.identity);
            newitem.gameObject.transform.SetParent(ins.Grid.transform);
            newitem.itemname = letter;
            newitem.Image.sprite = letter.Image;
            newitem.num.text = letter.Num.ToString();
        }


        public static void RefreshItem()
        {
            for (int i = 0; i < instance.Grid.transform.childCount; i++)
            {
                Destroy(instance.Grid.transform.GetChild(i).gameObject);
            }
            for (int i = 0; i < instance.Package.Count; i++)
            {
                CreateNewItem(instance.Package[i]);
            }
        }
    }
}