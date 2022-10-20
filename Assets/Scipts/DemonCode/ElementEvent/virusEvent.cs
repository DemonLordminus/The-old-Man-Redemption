using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class virusEvent : eventElmentFather
{
    public override void getEventPerform()
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger= true;
        DataManager.instance.controller.ChangeHealth(-10);
        Destroy(gameObject);
        Destroy(gameObject.transform.parent.gameObject);
    }
}
