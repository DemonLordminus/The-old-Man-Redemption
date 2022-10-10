using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CabinetsManager : MonoBehaviour
{
    private void Start()
    {
        Rigidbody2D Rigidbody2d = GetComponent<Rigidbody2D>();
        GetItem.Num = 0;
    }
    #region 碰撞
    //声明两个判断变量
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
        IsTrue = Guaiwu && Cabinets && Isshi && Isrun;
        if (IsTrue)
        {
            this.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            return;
        }
        if (playerController != null && !IsTrue)
        {
            AddNewItem();
            this.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
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
            Package.Items.Add(GetItem);
        }
        GetItem.Num += 1;
        PackageManager.RefreshItem();
    }
    #endregion
}
