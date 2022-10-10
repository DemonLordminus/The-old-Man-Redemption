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
    #region ��ײ
    //���������жϱ���
    public bool Medicine;
    public bool Guaiwu;
    public bool IsTrue;
    public bool Isshi;
    public bool Isrun;
    private void Update()
    {

        //�������жϻ�ȡֵ
        try
        {
            Medicine = GameObject.FindWithTag("citiao").GetComponent<CitiaoManager>().isgreen;
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

    #region ��ȡ
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
