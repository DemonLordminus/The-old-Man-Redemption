using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public GameObject close;
    public GameObject original;
    private void OnEnable()
    {
        GameObject gameObject =Instantiate(close,original.transform.position,Quaternion.identity);
        gameObject.transform.SetParent(this.gameObject.transform);
        gameObject.GetComponent<Close>().Dialog = this.gameObject;
    }
}
