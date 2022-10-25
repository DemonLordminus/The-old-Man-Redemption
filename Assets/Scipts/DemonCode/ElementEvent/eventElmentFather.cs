using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventElmentFather : LawOrActLists
{
    [Range(0, 100)]
    public float random;
    public bool isGood;
    public string information;
    // Start is called before the first frame update
    public GameObject shade;
    public void changeForGoodOrBad()
    {
        if(isGood)
        {
            shade.SetActive(false);
        }
    }
    public void selfDestroyLater()
    {
        Invoke("DestroyForInvoke",0.1f);
    }
    private void DestroyForInvoke()
    {
        if(gameObject.transform.parent.transform.childCount <= 1)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
        Destroy(gameObject);
    }
    public virtual void getEventPerform() 
    { 
        
    }
}
