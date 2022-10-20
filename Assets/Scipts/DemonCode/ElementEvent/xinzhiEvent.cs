using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xinzhiEvent : eventElmentFather
{
    [SerializeField]
    public GetItem[] item;
    // Start is called before the first frame update


    // Update is called once per frame

    public override void getEventPerform()
    {
        //item = gameObject.GetComponent<GetItem[]>();
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        DataManager.instance.controller.AddNewItem(item);
        Debug.Log("–≈÷ΩªÒ»°");
        Destroy(gameObject);
    }
}
