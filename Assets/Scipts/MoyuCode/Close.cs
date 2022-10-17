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
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        HintColor = Color.black;
        image = GetComponent<Image>();
    }
    private void FixedUpdate()
    {
        timer+=Time.fixedDeltaTime;
        if (timer > 2f)
        {
            HintColor.a = Mathf.PingPong(5 * Time.time, 1F);//5*Time.time����˸Ƶ�ʣ���ҿ����Լ��ģ�1F������ɫ��a������ֵ����˼���Ǵ���ȫ͸������ȫ��͸��
            image.color = HintColor;//��ȡUI��image�������ɫ��������仯��hintcolor��ֵ����
        }
    }
    //������ʼ����
    public Transform originalParent;
    public Transform originalPosition;
    //���������
    public void OnBeginDrag(PointerEventData eventData)
    {
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
        delta = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - originalPosition.position.y;
        if(delta<0)
        {
            transform.SetParent(originalParent);
            transform.position = originalPosition.position;
            Dialog.SetActive(false);
            GameObject.Find("Player").GetComponent<PlayerController>().isPalse = false;
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
        position.y=eventData.position.y;
        Rigidbody2D.position = position;
    }


}

