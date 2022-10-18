using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
//��������Ʒ��ʹ�ã���ק����������Ч
public class ItemOnDrag: MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //������ʼ����
    public Transform originalParent;
    public GetItem GetItem;
    public Package Package;
    public GameObject traggerManager;
    private void Start()
    {
        traggerManager = GameObject.Find("TraggerManager");
        Package = GameObject.Find("UI").GetComponent<PackageManager>().Package;
        GetItem=this.gameObject.GetComponent<Item>().itemname;
    }
    //���������
    public void OnBeginDrag(PointerEventData eventData)
    {
        //��ʼ������ֵ
        originalParent = transform.parent;
        //������������
        transform.SetParent(transform.parent.parent);
        //��������ƶ�
        transform.position = eventData.position;
        //�޸����������ԣ���ֹ�������ߴ�͸
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    //����ɿ���ק����
    public void OnEndDrag(PointerEventData eventData)
    {
        try
        {
            if (eventData.pointerCurrentRaycast.gameObject.tag == "Package")//��������ȡ�������������ײ�������ͼ��     //citiao����λ��
            {
                //ʹ��ק����鵽��굱ǰλ�õĿ���
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
                //ʹԭ�ж��󷵻ص���ק�����ԭʼλ��
                eventData.pointerCurrentRaycast.gameObject.transform.position = originalParent.position;
                eventData.pointerCurrentRaycast.gameObject.transform.SetParent(originalParent);
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;//�˳�
            }
            if (eventData.pointerCurrentRaycast.gameObject.name == "Player")//������ȷλ��
            {
                PlayerController playerController = eventData.pointerCurrentRaycast.gameObject.GetComponent<PlayerController>();
                if (playerController != null)
                {
                    switch (GetItem.Name)
                    {
                        case "Yaoping": playerController.ChangeHealth(10); break;
                        case "xin":if(!traggerManager.GetComponent<TraggerManager>().Open())
                            {
                                GetItem.Num+=1;
                            };break;
                        default: break;
                    }
                    GetItem.Num -= 1;
                    if(GetItem.Num==0)
                    {
                        Package.Items.Remove(GetItem);
                    }
                    PackageManager.RefreshItem();
                    Destroy(this.gameObject);
                    GetComponent<CanvasGroup>().blocksRaycasts = true;
                }
                return;//�˳�
            }
        }
        catch
        { }
        transform.SetParent(originalParent);
        transform.position = originalParent.GetChild(0).position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
    //�����ק����
    public void OnDrag(PointerEventData eventData)
    {
        //�������
        transform.position = eventData.position;
    }


}
