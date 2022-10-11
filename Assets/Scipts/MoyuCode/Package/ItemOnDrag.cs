using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemOnDrag: MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //������ʼ����
    public Transform originalParent;
    public GetItem GetItem;
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
                    playerController.ChangeHealth(10);
                    GetItem.Num -= 1;
                    PackageManager.RefreshItem();
                    Destroy(this.gameObject);
                    GetComponent<CanvasGroup>().blocksRaycasts = true;
                }
                return;//�˳�
            }
        }
        catch
        { }
        transform.parent = originalParent;
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
