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
    //�����յ���Ϸ����
    GameObject IfMedicine;
    GameObject IfGuaiwu;
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
