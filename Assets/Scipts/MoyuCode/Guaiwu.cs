using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Guaiwu : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //������ʼ����
    public Transform originalParent;
    //�����ж��Ƿ�Ϊ����
    public bool Isguaiwu;
    //���������
    public void OnBeginDrag(PointerEventData eventData)
    {
        //��ʼ������ֵ
        originalParent =transform.parent;
        //������������
        transform.SetParent(transform.parent.parent.parent);
        //��������ƶ�
        transform.position= eventData.position;
        //�޸����������ԣ���ֹ�������ߴ�͸
        GetComponent<CanvasGroup>().blocksRaycasts=false;
    }
    //����ɿ���ק����
    public void OnEndDrag(PointerEventData eventData)
    {
        //��ʼ��
        Isguaiwu=false;
        try
        {
            if (eventData.pointerCurrentRaycast.gameObject.layer == 3)//��������ȡ�������������ײ�������ͼ��     //citiao����λ��
            {
                //ʹ��ק����鵽��굱ǰλ�õĿ���
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.position;
                //ʹԭ�ж��󷵻ص���ק�����ԭʼλ��
                eventData.pointerCurrentRaycast.gameObject.transform.position = originalParent.position;
                eventData.pointerCurrentRaycast.gameObject.transform.SetParent(originalParent);
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;//�˳�
            }
            if (eventData.pointerCurrentRaycast.gameObject.tag == "TraggerNum")//������ȷλ��
            {
                if (eventData.pointerCurrentRaycast.gameObject.name == "1")
                { Isguaiwu = true; }
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;//�˳�
            }
            if (eventData.pointerCurrentRaycast.gameObject.tag == "None")//�޸���ʾbug
            {
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.GetChild(0).transform);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.GetChild(0).position;
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;//�˳�
            }
            if (eventData.pointerCurrentRaycast.gameObject.tag == "Grid" || eventData.pointerCurrentRaycast.gameObject.tag == "Grid1")
            {
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }
        }
        catch
        { }
        transform.parent = originalParent;
        transform.position = originalParent.transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;

    }
    //�����ק����
    public void OnDrag(PointerEventData eventData)
    {
        //�������
        transform.position = eventData.position;
    }

    
}
