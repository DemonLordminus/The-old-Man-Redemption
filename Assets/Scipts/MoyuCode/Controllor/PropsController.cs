using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
//��Ʒ�Ĺ�������������ȡ��Ʒ
public class PropsController : MonoBehaviour
{
    private void Start()
    {
        Rigidbody2D Rigidbody2d = GetComponent<Rigidbody2D>();
        GetItem.Num = 0;
        Package.Items.Clear();
    }
    #region ��ײ
    //�����жϱ���
    public bool Medicine;
    public bool Cabinets;
    public bool Guaiwu;
    public bool IsTrue;
    public bool Isshi;
    public bool Isrun;
    private void Update()
    {

        //���жϻ�ȡֵ
        try
        {
            
        }
        catch
        { }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�ж��Ƿ���յ���
        Isrun = GameObject.FindWithTag("mailbox").GetComponent<MailBoxManager>().isrun;
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        switch(GetItem.Name)//����GetItem����е�Name�������ж��Ƿ�����
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
            if(GetItem.Name=="Yaoping")
            {
                this.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
                if(collision.gameObject.GetComponent<PlayerController>().Gold > 50)
                {
                    AddNewItem();
                    collision.gameObject.GetComponent<PlayerController>().Gold -= 50;
                }
                return;
            }
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
