using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
//����ϵͳ������ʹ������Ч���ƶ�
public class CitiaoControllor : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //������ʼ����
    public Transform originalPosition;
    private bool isOnLetter;//Demon�����ñ������Ƿ�������

    //���������
    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetAsLastSibling();
        //��ʼ������ֵ
        originalPosition = transform;
        //��������ƶ�
        transform.position = eventData.position;
        //�޸����������ԣ�ʹ�������ߴ�͸��ǰ����
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    //��������ק����
    public void OnEndDrag(PointerEventData eventData)
    {
        try//��ֹ���ȡ��ֵ�쳣
        {
            if (/*eventData.pointerCurrentRaycast.gameObject.layer == 3&&*/transform.parent.tag=="Tragger")//��������ȡ�������������ײ�������ͼ��     
            {
                /*//���õ�ǰ����λ��
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;*/
                //���õ�ǰ��������
                transform.SetParent(GameObject.Find("inventory").transform);
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }
            //�������������Ҵ����ڴ�������
            if(eventData.pointerCurrentRaycast.gameObject.name== "Lajitong")
            {
                Destroy(gameObject);
            }
            if(eventData.pointerCurrentRaycast.gameObject.layer == 3 && eventData.pointerCurrentRaycast.gameObject.transform.parent.tag == "Tragger")
            {
                //���õ�ǰ��������
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent);
                //���õ�ǰ����λ��
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
                //��������ȡ����λ��
                eventData.pointerCurrentRaycast.gameObject.transform.position = originalPosition.position;
                //��������ȡ��������
                eventData.pointerCurrentRaycast.gameObject.transform.SetParent(originalPosition.parent);
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }
            //����������
            if (eventData.pointerCurrentRaycast.gameObject.tag == "Tragger") //������ȷλ�ã�ʹ������������Ӧ������Ч
            {
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                isOnLetter = true;
                return;
            }
            else {
                
                isOnLetter = false; 
            }
        }
        catch
        { }
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
    //��Ʒ�������
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

}