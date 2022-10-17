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
    public string what;
    public bool avoid;
    public bool bad;
    public bool cabinets;
    public bool eat;
    public bool entry;
    public bool exercise;
    public bool good;
    public bool hospital;
    public bool HRM;
    public bool illness;
    public bool pharmacy;
    public bool relax;
    public bool shi;
    public bool TCM;
    //��ȡ����������
    void JudgeWhat()
    {
        citiao citiao = this.gameObject.GetComponent<citiao>();
        switch(citiao.citiaoName.Name)
        {
            case "avoid":what="avoid"; break;
            case "bad":what="bad"; break;
            case "cabinets":what="cabinets"; break;
            case "eat":what ="eat"; break;
            case "entry":what="entry"; break;
            case "exercise":what="exercise"; break;
            case "good":what="good"; break;
            case "hospital":what="hospital"; break;
            case "HRM":what="HRM"; break;
            case "illness":what="illness"; break;
            case "pharmacy":what="pharmacy"; break;
            case "relax":what="relax"; break;
            case "shi":what="shi"; break;
            case "TCM":what="TCM"; break;
                default:break;
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
            if (eventData.pointerCurrentRaycast.gameObject.tag == "Tragger") //������ȷλ�ã�ʹ������������Ӧ������Ч
            {
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