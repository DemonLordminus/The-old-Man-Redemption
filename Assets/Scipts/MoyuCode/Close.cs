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
            HintColor.a = Mathf.PingPong(5 * Time.time, 1F);//5*Time.time是闪烁频率，1F就是颜色的a的最大的值，意思就是从完全透明到完全不透明
            image.color = HintColor;//获取UI的image组件的颜色并把上面变化的hintcolor赋值给他
        }
    }
    //声明起始组类
    public Transform originalParent;
    public Transform originalPosition;
    //鼠标点击触发
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("huoqu");
        originalPosition = transform;
        //起始所属赋值
        originalParent = transform.parent;
        //跳出所属画布
        transform.SetParent(transform.parent.parent);
        //跟随鼠标移动
        transform.position = eventData.position;
        //修改这个类的属性，使物理射线穿透当前对象
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    //鼠标结束拖拽触发
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
    //物品跟随鼠标
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position = transform.position;
        position.x=eventData.position.x;
        Rigidbody2D.position = position;
    }


}

