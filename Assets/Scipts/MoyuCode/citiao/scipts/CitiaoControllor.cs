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
    public int whatNo;
    public string what;

    private bool isOnLetter;//Demon测试用变量，是否在信上

    //获取属性来区分
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
    //鼠标点击触发
    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetAsLastSibling();
        //起始所属赋值
        originalParent = transform.parent;
        //跳出所属画布
        //transform.SetParent(transform.parent.parent.parent);
        //跟随鼠标移动
        transform.position = eventData.position;
        //修改这个类的属性，使物理射线穿透当前对象
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    //鼠标结束拖拽触发
    public void OnEndDrag(PointerEventData eventData)
    {
        citiao citiao = this.gameObject.GetComponent<citiao>();
        what = citiao.citiaoName;
        JudgeWhat();
        try//防止因获取空值异常
        {
            #region
            //if (eventData.pointerCurrentRaycast.gameObject.layer == 3)//这个代码获取鼠标射线现在碰撞的物体的图层     //citiao调换位置
            //{
            //    //设置当前对象所属
            //    transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent);
            //    //设置当前对象位置
            //    transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.position;
            //    //设置鼠标获取对象位置
            //    eventData.pointerCurrentRaycast.gameObject.transform.position = originalParent.position;
            //    //设置鼠标获取对象所属
            //    eventData.pointerCurrentRaycast.gameObject.transform.SetParent(originalParent);
            //    GetComponent<CanvasGroup>().blocksRaycasts = true;
            //    return;
            //}
            //if (eventData.pointerCurrentRaycast.gameObject.tag == "None")//修复显示bug
            //{
            //    transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.GetChild(0).transform);
            //    transform.position = eventData.pointerCurrentRaycast.gameObject.transform.GetChild(0).position;
            //    GetComponent<CanvasGroup>().blocksRaycasts = true;
            //    return;//退出
            //}
            //定到词条存储区
            //if (eventData.pointerCurrentRaycast.gameObject.tag == "Grid" || eventData.pointerCurrentRaycast.gameObject.tag == "Grid1")
            //{
            //    transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
            //    transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
            //    GetComponent<CanvasGroup>().blocksRaycasts = true;
            //    return;
            //}
            #endregion
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
        //如果放到错误位置直接归位
        //transform.SetParent(originalParent);
        //transform.position = originalParent.transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;

    }
    //物品跟随鼠标
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

}