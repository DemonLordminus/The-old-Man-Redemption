using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseManager : MonoBehaviour
{
    public InkManager inkM;
    public Texture2D ink, normal;
    public bool ifUseInk;
    public GameObject text;
    private LayerMask mask;
    void Start()
    {
        mask = LayerMask.GetMask("Item");
        Cursor.SetCursor(normal, new Vector2(0, 0), CursorMode.Auto);
    }/*
    private void Update() //��һ�Ѳ��� ����Ҫ��
    {
        if (inkM != null)
        {
            ifUseInk = inkM.GetComponent<InkManager>().ifUseInk;
            if (ifUseInk)
            {
                Cursor.SetCursor(ink, new Vector2(16, 16), CursorMode.Auto);
            }
            else
            {
                Cursor.SetCursor(normal, new Vector2(0, 0), CursorMode.Auto); //��Ϊ0��0 ����ָ��
            }
        }
    }*/
    /*GameObject game;
    private void OnCollisionEnter(Collision collision)
    {
        WhatScipts whatScipts=collision.gameObject.GetComponent<WhatScipts>();
        if(whatScipts!=null)
        {
            text.GetComponent<TextMeshProUGUI>().text = game.GetComponent<TextMeshProUGUI>().text;
            Instantiate(text, Input.mousePosition, Quaternion.identity);
        }
    }*/
    /*void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, mask))
        {
            text.transform.position = hitInfo.point;
            text.GetComponent<TextMeshProUGUI>().text = hitInfo.collider.gameObject.name;
            //�ѻ�ȡ������ײ����Ķ����������ʾ��UI�����
            //Debug.DrawLine(Camera.main.transform.position, hitInfo.point);
            //������ʾ���ߣ����ù�
        }
        else
        {
            text.GetComponent<TextMeshProUGUI>().text = "";
        }
    }*/
    private void OnMouseEnter()
    {
        
    }
    /*
    private void OnMouseOver()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            game=hit.transform.gameObject;
        }
        
        try
        {
            WhatScipts whatScipts = game.GetComponent<WhatScipts>();
            if (whatScipts != null)
            {
                text.GetComponent<TextMeshProUGUI>().text =game.GetComponent<TextMeshProUGUI>().text;
                Instantiate(text, Input.mousePosition, Quaternion.identity);
            }
        }
        catch
        { }
    }*/
}
