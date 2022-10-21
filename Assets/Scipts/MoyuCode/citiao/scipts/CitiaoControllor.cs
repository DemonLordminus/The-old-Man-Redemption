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
    private bool isOnLetter;//Demon测试用变量，是否在信上

    //鼠标点击触发
    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetAsLastSibling();
        //起始所属赋值
        originalParent = transform.parent;
        //跟随鼠标移动
        transform.position = eventData.position;
        //修改这个类的属性，使物理射线穿透当前对象
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    //鼠标结束拖拽触发
    public void OnEndDrag(PointerEventData eventData)
    {
        try//防止因获取空值异常
        {
            if (eventData.pointerCurrentRaycast.gameObject.layer == 3&&transform.parent.name=="tragger"||eventData.pointerCurrentRaycast.gameObject.layer==3&&eventData.pointerCurrentRaycast.gameObject.transform.parent.name=="tragger")//这个代码获取鼠标射线现在碰撞的物体的图层     //citiao调换位置
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
            //定到触发区
            if (eventData.pointerCurrentRaycast.gameObject.tag == "Tragger") //定到正确位置，使词条管理器对应属性生效
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
    //物品跟随鼠标
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

}