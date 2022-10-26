using Dmld;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhatScipts : MonoBehaviour
{
    private void Start()
    {
        switch (gameObject.GetComponent<Item>().itemname.Name)
        {
            case "保健品": { gameObject.AddComponent<Baojianpin>(); break; }
            case "解毒剂": { gameObject.AddComponent<Jieduji>(); break; }
            case "精神药物": { gameObject.AddComponent<Jsyw>();break; }
            case "抗生素": { gameObject.AddComponent<Kangshengsu>(); break; }
            case "能量饮料": { gameObject.AddComponent<Nlyl>(); break; }
            case "书籍": { gameObject.AddComponent<Shuji >(); break; }
            case "食物饮料": { gameObject.AddComponent<Swyl>(); break; }
            case "退烧药": { gameObject.AddComponent<Tuishaoyao>(); break; }
            case "胃药": { gameObject.AddComponent<Weiyao>(); break; }
            case "氧气瓶": { gameObject.AddComponent<Yangqiping>(); break; }
            case "烟酒": { gameObject.AddComponent<Yanjiu>(); break; }
            case "眼药水": { gameObject.AddComponent<Yanyaoshui >(); break; }
            case "止痛药": { gameObject.AddComponent<Zhitongyao>(); break; }
            case "中药": { gameObject.AddComponent<Zhongyao>(); break; }
            case "信": gameObject.AddComponent<Xin>(); break;
        }
    }
}
