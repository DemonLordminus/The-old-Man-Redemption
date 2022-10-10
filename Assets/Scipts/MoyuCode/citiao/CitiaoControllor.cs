using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class CitiaoControllor : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //声明起始组类
    public Transform originalParent;
    public bool green;
    public bool medicine;
    public bool cabinets;
    public bool guaiwu;
    public bool shi;
    //获取属性来区分
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
    //鼠标点击触发
    public void OnBeginDrag(PointerEventData eventData)
    {
        //起始所属赋值
        originalParent = transform.parent;
        //跳出所属画布
        transform.SetParent(transform.parent.parent.parent);
        //跟随鼠标移动
        transform.position = eventData.position;
        //修改这个类的属性，阻止物理射线穿透
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        JudgeWhat();
        try
        {
            if (eventData.pointerCurrentRaycast.gameObject.layer == 3)//这个代码获取鼠标射线现在碰撞的物体的图层     //citiao调换位置
            {
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.position;
                eventData.pointerCurrentRaycast.gameObject.transform.position = originalParent.position;
                eventData.pointerCurrentRaycast.gameObject.transform.SetParent(originalParent);
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }
            if (eventData.pointerCurrentRaycast.gameObject.tag == "None")//修复显示bug
            {
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.GetChild(0).transform);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.GetChild(0).position;
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;//退出
            }
            if (eventData.pointerCurrentRaycast.gameObject.tag == "Grid" || eventData.pointerCurrentRaycast.gameObject.tag == "Grid1")
            {
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }
            if (eventData.pointerCurrentRaycast.gameObject.tag == "1" || eventData.pointerCurrentRaycast.gameObject.tag == "2" || eventData.pointerCurrentRaycast.gameObject.tag == "3")//定到正确位置
            {
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
        transform.SetParent(originalParent);
        transform.position = originalParent.transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;

    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

}