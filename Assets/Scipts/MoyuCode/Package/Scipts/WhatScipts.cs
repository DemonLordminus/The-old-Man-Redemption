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
            case "����Ʒ": { gameObject.AddComponent<Baojianpin>(); break; }
            case "�ⶾ��": { gameObject.AddComponent<Jieduji>(); break; }
            case "����ҩ��": { gameObject.AddComponent<Jsyw>();break; }
            case "������": { gameObject.AddComponent<Kangshengsu>(); break; }
            case "��������": { gameObject.AddComponent<Nlyl>(); break; }
            case "�鼮": { gameObject.AddComponent<Shuji >(); break; }
            case "ʳ������": { gameObject.AddComponent<Swyl>(); break; }
            case "����ҩ": { gameObject.AddComponent<Tuishaoyao>(); break; }
            case "θҩ": { gameObject.AddComponent<Weiyao>(); break; }
            case "����ƿ": { gameObject.AddComponent<Yangqiping>(); break; }
            case "�̾�": { gameObject.AddComponent<Yanjiu>(); break; }
            case "��ҩˮ": { gameObject.AddComponent<Yanyaoshui >(); break; }
            case "ֹʹҩ": { gameObject.AddComponent<Zhitongyao>(); break; }
            case "��ҩ": { gameObject.AddComponent<Zhongyao>(); break; }
            case "��": gameObject.AddComponent<Xin>(); break;
        }
    }
}
