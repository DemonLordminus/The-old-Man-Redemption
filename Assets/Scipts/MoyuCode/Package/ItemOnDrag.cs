using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemOnDrag: MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //声明起始组类
    public Transform originalParent;
    public GetItem GetItem;
    //鼠标点击触发
    public void OnBeginDrag(PointerEventData eventData)
    {
        //起始所属赋值
        originalParent = transform.parent;
        //跳出所属画布
        transform.SetParent(transform.parent.parent);
        //跟随鼠标移动
        transform.position = eventData.position;
        //修改这个类的属性，阻止物理射线穿透
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    //鼠标松开拖拽触发
    public void OnEndDrag(PointerEventData eventData)
    {
        try
        {
            if (eventData.pointerCurrentRaycast.gameObject.tag == "Package")//这个代码获取鼠标射线现在碰撞的物体的图层     //citiao调换位置
            {
                //使拖拽对象归到鼠标当前位置的框中
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
                //使原有对象返回到拖拽对象的原始位置
                eventData.pointerCurrentRaycast.gameObject.transform.position = originalParent.position;
                eventData.pointerCurrentRaycast.gameObject.transform.SetParent(originalParent);
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;//退出
            }
            if (eventData.pointerCurrentRaycast.gameObject.name == "Player")//定到正确位置
            {
                PlayerController playerController = eventData.pointerCurrentRaycast.gameObject.GetComponent<PlayerController>();
                if (playerController != null)
                {
                    playerController.ChangeHealth(10);
                    GetItem.Num -= 1;
                    PackageManager.RefreshItem();
                    Destroy(this.gameObject);
                    GetComponent<CanvasGroup>().blocksRaycasts = true;
                }
                return;//退出
            }
        }
        catch
        { }
        transform.parent = originalParent;
        transform.position = originalParent.GetChild(0).position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
    //鼠标拖拽触发
    public void OnDrag(PointerEventData eventData)
    {
        //跟随鼠标
        transform.position = eventData.position;
    }


}
