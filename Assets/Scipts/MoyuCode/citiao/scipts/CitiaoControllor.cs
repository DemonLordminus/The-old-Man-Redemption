using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//using UnityEngine.UIElements;
//词条系统，用来使词条生效并移动
public class CitiaoControllor : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //声明起始组类
    public Transform originalPosition;
    private bool isOnLetter;//Demon测试用变量，是否在信上
    public Sprite[] images;
    public GameObject Lajitong;
    //鼠标点击触发
    public void OnBeginDrag(PointerEventData eventData)
    {
        Lajitong = DataManager.instance.Lajitong;
        transform.SetAsLastSibling();
        //起始所属赋值
        originalPosition = transform;
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
            if (/*eventData.pointerCurrentRaycast.gameObject.layer == 3&&*/transform.parent.tag=="Tragger")//这个代码获取鼠标射线现在碰撞的物体的图层     
            {
                /*//设置当前对象位置
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;*/
                //设置当前对象所属
                transform.SetParent(GameObject.Find("inventory").transform);
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }
            //遇到词条，并且词条在触发区上
            if(eventData.pointerCurrentRaycast.gameObject.tag== "Lajitong")
            {
                eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite = images[0];
                Destroy(gameObject);
            }
            if(eventData.pointerCurrentRaycast.gameObject.layer == 3 && eventData.pointerCurrentRaycast.gameObject.transform.parent.tag == "Tragger")
            {
                //设置当前对象所属
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent);
                //设置当前对象位置
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
                //设置鼠标获取对象位置
                eventData.pointerCurrentRaycast.gameObject.transform.position = originalPosition.position;
                //设置鼠标获取对象所属
                eventData.pointerCurrentRaycast.gameObject.transform.SetParent(originalPosition.parent);
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
        try
        {
            if (eventData.pointerCurrentRaycast.gameObject.tag == "Lajitong")
            {
                Lajitong.GetComponent<Image>().sprite = images[1];
            }
            if (eventData.pointerCurrentRaycast.gameObject.tag != "Lajitong")
            {
                Lajitong.GetComponent<Image>().sprite = images[0];
            }
        }
        catch
        { }
    }

}