using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PropsController : MonoBehaviour
{
    private void Start()
    {
        Rigidbody2D Rigidbody2d = GetComponent<Rigidbody2D>();
        GetItem.Num = 0;
        Package.Items.Clear();
    }
    #region 碰撞
    //声明两个判断变量
    public bool Medicine;
    public bool Cabinets;
    public bool Guaiwu;
    public bool IsTrue;
    public bool Isshi;
    public bool Isrun;
    private void Update()
    {

        //给两个判断获取值
        try
        {
            Cabinets = GameObject.FindWithTag("citiao").GetComponent<CitiaoManager>().iscabinets;
            Medicine = GameObject.FindWithTag("citiao").GetComponent<CitiaoManager>().ismedicine;
            Guaiwu = GameObject.FindWithTag("citiao").GetComponent<CitiaoManager>().isguaiwu;
            Isshi = GameObject.FindWithTag("citiao").GetComponent<CitiaoManager>().isshi;
        }
        catch
        { }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Isrun = GameObject.FindWithTag("mailbox").GetComponent<MailBoxManager>().isrun;
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        switch(GetItem.Name)
        {
            case "medicine": IsTrue = Guaiwu && Medicine && Isshi && Isrun;
                break;
            case "Yaoping": IsTrue = Guaiwu && Cabinets && Isshi && Isrun;
                break;
                default: break;
        }
        if (IsTrue)
        {
            this.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            return;
        }
        if (playerController != null && !IsTrue)
        {
            AddNewItem();
            if(GetItem.Name=="Yaoping")
            {
                this.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
                return;
            }
            Destroy(this.gameObject);
            Destroy(this.transform.parent.gameObject);
        }
    }
    #endregion

    #region 获取
    public GetItem GetItem;
    public Package Package;

    public void AddNewItem()
    {
        if (!Package.Items.Contains(GetItem))
        {
            GetItem.Num = 1;
            Package.Items.Add(GetItem);
        }
        else
        {
            GetItem.Num += 1;
        }
        PackageManager.RefreshItem();
    }
    #endregion
}
