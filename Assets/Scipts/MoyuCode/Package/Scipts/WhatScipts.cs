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
            case "baojianping": { gameObject.AddComponent<Baojianpin>(); break; }
            case "jieduji": { gameObject.AddComponent<Jieduji>(); break; }
            case "jsyw": { gameObject.AddComponent<Jsyw>();break; }
            case "kangshengsu": { gameObject.AddComponent<Kangshengsu>(); break; }
            case "nlyl": { gameObject.AddComponent<Nlyl>(); break; }
            case "shuji": { gameObject.AddComponent<Shuji >(); break; }
            case "swyl": { gameObject.AddComponent<Swyl>(); break; }
            case "tuishaoyao": { gameObject.AddComponent<Tuishaoyao>(); break; }
            case "weiyao": { gameObject.AddComponent<Weiyao>(); break; }
            case "yangqiping": { gameObject.AddComponent<Yangqiping>(); break; }
            case "yanjiu": { gameObject.AddComponent<Yanjiu>(); break; }
            case "yanyaoshui": { gameObject.AddComponent<Yanyaoshui >(); break; }
            case "zhitongyao": { gameObject.AddComponent<Zhitongyao>(); break; }
            case "zhongyao": { gameObject.AddComponent<Zhongyao>(); break; }
            case "xin": break;
        }
    }
}
