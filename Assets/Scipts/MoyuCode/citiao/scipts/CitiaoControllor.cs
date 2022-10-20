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
    public int whatNo;
    public string what;

    private bool isOnLetter;//Demon�����ñ������Ƿ�������

    //��ȡ����������
    void JudgeWhat()
    {
        switch( what)
        {
            case "avoid": { whatNo=0; break; }
            case "bad": {  whatNo=1; break; }
            case "cabinets": { whatNo=2; break; }
            //case "cabinets_bad": { whatNo =3; break; }
            case "eat": { whatNo =4; break; }

            case "entry": { whatNo =5; break; }
            case "exercise": { whatNo =6; break; }
            case "good": { whatNo =7; break; }
            case "hospital": {whatNo =8; break; }
            //case "hospital_bad": { whatNo =9; break; }

            case "HRM": { whatNo =10; break; }
            //case "HRM_bad": { whatNo=11; break; }
            case "illness": { whatNo =12; break; }
            //case "illness_bad": {whatNo =13; break; }
            case "pharmacy": { whatNo=14; break; }

            //case "pharmacy_bad": {whatNo=15; break; }
            case "relax": { whatNo=16; break; }
            case "shi": { whatNo =17; break; }
            case "TCM": { whatNo =18; break; }
            //case "TCM_bad": { whatNo =19; break; }
        }
    }
    //���������
    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetAsLastSibling();
        //��ʼ������ֵ
        originalParent = transform.parent;
        //������������
        //transform.SetParent(transform.parent.parent.parent);
        //��������ƶ�
        transform.position = eventData.position;
        //�޸����������ԣ�ʹ�������ߴ�͸��ǰ����
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    //��������ק����
    public void OnEndDrag(PointerEventData eventData)
    {
        citiao citiao = this.gameObject.GetComponent<citiao>();
        what = citiao.citiaoName;
        JudgeWhat();
        try//��ֹ���ȡ��ֵ�쳣
        {
            #region
            //if (eventData.pointerCurrentRaycast.gameObject.layer == 3)//��������ȡ�������������ײ�������ͼ��     //citiao����λ��
            //{
            //    //���õ�ǰ��������
            //    transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent);
            //    //���õ�ǰ����λ��
            //    transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.position;
            //    //��������ȡ����λ��
            //    eventData.pointerCurrentRaycast.gameObject.transform.position = originalParent.position;
            //    //��������ȡ��������
            //    eventData.pointerCurrentRaycast.gameObject.transform.SetParent(originalParent);
            //    GetComponent<CanvasGroup>().blocksRaycasts = true;
            //    return;
            //}
            //if (eventData.pointerCurrentRaycast.gameObject.tag == "None")//�޸���ʾbug
            //{
            //    transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.GetChild(0).transform);
            //    transform.position = eventData.pointerCurrentRaycast.gameObject.transform.GetChild(0).position;
            //    GetComponent<CanvasGroup>().blocksRaycasts = true;
            //    return;//�˳�
            //}
            //���������洢��
            //if (eventData.pointerCurrentRaycast.gameObject.tag == "Grid" || eventData.pointerCurrentRaycast.gameObject.tag == "Grid1")
            //{
            //    transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
            //    transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
            //    GetComponent<CanvasGroup>().blocksRaycasts = true;
            //    return;
            //}
            #endregion
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
        //����ŵ�����λ��ֱ�ӹ�λ
        //transform.SetParent(originalParent);
        //transform.position = originalParent.transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;

    }
    //��Ʒ�������
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

}