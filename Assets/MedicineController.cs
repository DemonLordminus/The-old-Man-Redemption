using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MedicineController : MonoBehaviour
{
    private void Start()
    {
        Rigidbody2D Rigidbody2d = GetComponent<Rigidbody2D>();
        GetItem.Num = 0;
        Package.Items.Clear();
    }
    #region 碰撞
    //声明空的游戏对象
    GameObject IfMedicine;
    GameObject IfGuaiwu;
    //声明两个判断变量
    public bool Medicine;
    public bool Guaiwu;
    public bool IsTrue;
    public bool Isshi;
    public bool Isrun;
    private void Update()
    {

        //给两个判断获取值
        try
        {
            IfMedicine = GameObject.FindWithTag("Yao");
            IfGuaiwu = GameObject.FindWithTag("Guaiwu");
            Medicine = IfMedicine.GetComponent<Medicine>().IsMedicine;
            Guaiwu = IfGuaiwu.GetComponent<Guaiwu>().Isguaiwu;
            Isshi = GameObject.FindWithTag("shi").GetComponent<Shi>().Isshi;
        }
        catch
        { }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Isrun = GameObject.FindWithTag("mailbox").GetComponent<MailBoxManager>().isrun;
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        IsTrue = Guaiwu && Medicine&&Isshi&&Isrun;
        if (IsTrue)
        {
            this.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            return;
        }
        if (playerController != null && !IsTrue)
        {
            AddNewItem();
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
            Package.Items.Add(GetItem);
        }
            GetItem.Num += 1;
        PackageManager.RefreshItem();
    }
    #endregion
}
