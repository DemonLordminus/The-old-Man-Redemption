using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PharmacyEvent : eventElmentFather
{
    [SerializeField]
    public GetItem[] items;
    public override void getEventPerform()
    {
        
        if (OnLaw("Ò©µêÊÇ»µµÄ")|| OnAct("±Ü¿ªÒ©µê"))
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            DataManager.instance.controller.AddNewItem(items);
            DataManager.instance.controller.Gold-=50;
        }
        else
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
}
