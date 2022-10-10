using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MailBoxManager : MonoBehaviour
{
    public bool ishave;
    public bool isrun;
    private void Start()
    {
        //初始化
        ishave = false;
        isrun = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player" && ishave == true)//老人触发并且信箱内有信
        {
            ishave=false;
            isrun =true;
            this.GetComponent<BoxCollider2D>().isTrigger=true;//使主角能穿过
        }
        if(collision.gameObject.tag=="Player")
        {
            this.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
}
