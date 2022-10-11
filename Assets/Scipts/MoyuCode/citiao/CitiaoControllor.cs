using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
//����ϵͳ������ʹ������Ч���ƶ�
public class CitiaoControllor : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //������ʼ����
    public Transform originalParent;
    //�����жϱ���
    public bool green;
    public bool medicine;
    public bool cabinets;
    public bool guaiwu;
    public bool shi;
    //��ȡ����������
    void JudgeWhat()
    {
        citiao citiao = this.gameObject.GetComponent<citiao>();
        if (citiao.citiaoName.Name == "green")
        {
            green = true;
        }
        if (citiao.citiaoName.Name == "medicine")
        {
            medicine = true;
        }
        if (citiao.citiaoName.Name == "Cabinets")
        {
            cabinets = true;
        }
        if (citiao.citiaoName.Name == "guaiwu")
        {
            guaiwu = true;
        }
        if (citiao.citiaoName.Name == "shi")
        {
            shi = true;
        }
    }
    //���������
    public void OnBeginDrag(PointerEventData eventData)
    {
        //��ʼ������ֵ
        originalParent = transform.parent;
        //������������
        transform.SetParent(transform.parent.parent.parent);
        //��������ƶ�
        transform.position = eventData.position;
        //�޸����������ԣ�ʹ�������ߴ�͸��ǰ����
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    //��������ק����
    public void OnEndDrag(PointerEventData eventData)
    {
        JudgeWhat();
        try//��ֹ���ȡ��ֵ�쳣
        {
            if (eventData.pointerCurrentRaycast.gameObject.layer == 3)//��������ȡ�������������ײ�������ͼ��     //citiao����λ��
            {
                //���õ�ǰ��������
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent);
                //���õ�ǰ����λ��
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.position;
                //��������ȡ����λ��
                eventData.pointerCurrentRaycast.gameObject.transform.position = originalParent.position;
                //��������ȡ��������
                eventData.pointerCurrentRaycast.gameObject.transform.SetParent(originalParent);
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }
            if (eventData.pointerCurrentRaycast.gameObject.tag == "None")//�޸���ʾbug
            {
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.GetChild(0).transform);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.GetChild(0).position;
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;//�˳�
            }
            //���������洢��
            if (eventData.pointerCurrentRaycast.gameObject.tag == "Grid" || eventData.pointerCurrentRaycast.gameObject.tag == "Grid1")
            {
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }
            //����������
            if (eventData.pointerCurrentRaycast.gameObject.tag == "1" || eventData.pointerCurrentRaycast.gameObject.tag == "2" || eventData.pointerCurrentRaycast.gameObject.tag == "3")
            {
                //������ȷλ�ã�ʹ������������Ӧ������Ч
                if (eventData.pointerCurrentRaycast.gameObject.tag == "1")
                {
                    if (green == true)
                    {
                        GameObject.FindWithTag("citiao").GetComponent<CitiaoManager>().isgreen=true;
                    }
                    if (medicine == true)
                    {
                        GameObject.FindWithTag("citiao").GetComponent<CitiaoManager>().ismedicine = true;
                    }
                    if (cabinets == true)
                    {
                        GameObject.FindWithTag("citiao").GetComponent<CitiaoManager>().iscabinets = true;
                    }
                }
                if (eventData.pointerCurrentRaycast.gameObject.tag == "2")
                {
                    if (shi == true)
                    {
                        GameObject.FindWithTag("citiao").GetComponent<CitiaoManager>().isshi = true;
                    }
                }
                if (eventData.pointerCurrentRaycast.gameObject.tag == "3")
                {
                    if (guaiwu == true)
                    {
                        GameObject.FindWithTag("citiao").GetComponent<CitiaoManager>().isguaiwu = true;
                    }
                }
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }
        }
        catch
        { }
        //����ŵ�����λ��ֱ�ӹ�λ
        transform.SetParent(originalParent);
        transform.position = originalParent.transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;

    }
    //��Ʒ�������
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

}