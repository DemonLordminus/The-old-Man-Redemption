using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
//词条系统，用来使词条生效并移动
public class CitiaoControllor : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //声明起始组类
    public Transform originalParent;
    //声明判断变量
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
        //修改这个类的属性，使物理射线穿透当前对象
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    //鼠标结束拖拽触发
    public void OnEndDrag(PointerEventData eventData)
    {
        JudgeWhat();
        try//防止因获取空值异常
        {
            if (eventData.pointerCurrentRaycast.gameObject.layer == 3)//这个代码获取鼠标射线现在碰撞的物体的图层     //citiao调换位置
            {
                //设置当前对象所属
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent);
                //设置当前对象位置
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.position;
                //设置鼠标获取对象位置
                eventData.pointerCurrentRaycast.gameObject.transform.position = originalParent.position;
                //设置鼠标获取对象所属
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
            //定到词条存储区
            if (eventData.pointerCurrentRaycast.gameObject.tag == "Grid" || eventData.pointerCurrentRaycast.gameObject.tag == "Grid1")
            {
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }
            //定到触发区
            if (eventData.pointerCurrentRaycast.gameObject.tag == "1" || eventData.pointerCurrentRaycast.gameObject.tag == "2" || eventData.pointerCurrentRaycast.gameObject.tag == "3")
            {
                //定到正确位置，使词条管理器对应属性生效
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
        //如果放到错误位置直接归位
        transform.SetParent(originalParent);
        transform.position = originalParent.transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;

    }
    //物品跟随鼠标
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

}