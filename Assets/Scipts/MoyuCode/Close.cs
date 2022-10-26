using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Close : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public GameObject Dialog;
    private Color HintColor;
    Image image;
    public float timer;
    Rigidbody2D Rigidbody2D;
    public GameObject position;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        HintColor = Color.black;
        image = GetComponent<Image>();
    }
    private void OnDisable()
    {
        gameObject.transform.parent.transform.GetChild(0).gameObject.GetComponent<Text>().text = "";
        Destroy(gameObject);
    }
    private void FixedUpdate()
    {
        timer+=Time.fixedDeltaTime;
        if (timer > 2f)
        {
            HintColor.a = Mathf.PingPong(5 * Time.time, 1F);//5*Time.time����˸Ƶ�ʣ�1F������ɫ��a������ֵ����˼���Ǵ���ȫ͸������ȫ��͸��
            image.color = HintColor;//��ȡUI��image�������ɫ��������仯��hintcolor��ֵ����
        }
    }
    //������ʼ����
    public Transform originalParent;
    public Transform originalPosition;
    //���������
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("huoqu");
        originalPosition = transform;
        //��ʼ������ֵ
        originalParent = transform.parent;
        //������������
        transform.SetParent(transform.parent.parent);
        //��������ƶ�
        transform.position = eventData.position;
        //�޸����������ԣ�ʹ�������ߴ�͸��ǰ����
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    //��������ק����
    public float delta;
    public void OnEndDrag(PointerEventData eventData)
    {
        delta = (Camera.main.ScreenToWorldPoint(Input.mousePosition).x - originalPosition.position.x);
        if(delta<0)
        {
            transform.SetParent(originalParent);
            transform.position = originalPosition.position;
            Dialog.SetActive(false);
            DataManager.instance.controller.isPalse = false;
            try
            {
                if (DataManager.instance.JuQingFinishin.Count == 14)
                {
                    DataManager.instance.controller.isPalse = true;
                    DataManager.instance.EndEvent.SetActive(true);
                }
            }
            catch
            { }
            return;
        }
        transform.SetParent(originalParent);
        transform.position = originalPosition.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
    //��Ʒ�������
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position = transform.position;
        position.x=eventData.position.x;
        Rigidbody2D.position = position;
    }


}

