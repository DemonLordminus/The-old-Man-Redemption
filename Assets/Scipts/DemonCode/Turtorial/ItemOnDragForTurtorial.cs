using Cinemachine;
using Dmld;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//背包中物品的使用，拖拽到主角上生效
namespace tur
{
    public class ItemOnDragForTurtorial : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        //声明起始组类
        public Transform originalParent;
        public GetItem GetItem;
        public GameObject traggerManager;
        public GameObject tragger;
        public int count1 = 0;
        public float kangshengsu = 5;
        public float swyl;//食物饮料的回复量
        public PlayerControlForTurtorial playerController;
        public CinemachineVirtualCamera virtualCamera;//这里的对象还需设置
        private void Start()
        {
            //playerController = DataManager.instance.controller;
            traggerManager = GameObject.Find("TraggerManager");
            GetItem = this.gameObject.GetComponent<Item>().itemname;
        }
        //鼠标点击触发
        public void OnBeginDrag(PointerEventData eventData)
        {
            //起始所属赋值
            originalParent = transform.parent;
            //跳出所属画布
            //transform.SetParent(transform.parent.parent);
            //跟随鼠标移动
            transform.position = eventData.position;
            //修改这个类的属性，阻止物理射线穿透
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
        //鼠标松开拖拽触发
        public void OnEndDrag(PointerEventData eventData)
        {
            Vector3 vector = Input.mousePosition - gameObject.transform.parent.transform.position;
            Debug.Log(vector.x);
            int delta = (int)vector.x;
            try
            {
                if (delta < 0)//这个代码获取鼠标射线现在碰撞的物体的图层     //citiao调换位置
                {
                    //使拖拽对象归到鼠标当前位置的框中
                    transform.position = eventData.position;
                    //SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent);
                    //transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
                    //使原有对象返回到拖拽对象的原始位置
                    //eventData.pointerCurrentRaycast.gameObject.transform.position = originalParent.position;
                    //eventData.pointerCurrentRaycast.gameObject.transform.SetParent(originalParent);
                    GetComponent<CanvasGroup>().blocksRaycasts = true;
                    return;//退出
                }
            }
            catch
            { }
            ItemOnRun();
            GetItem.Num -= 1;
            if (GetItem.Num <= 0)
            {
                playerController.ItemsPackage.Remove(GetItem);
            }
            //PackageManagerForTurtorial.RefreshItem();
            Destroy(this.gameObject);
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        //鼠标拖拽触发
        public void OnDrag(PointerEventData eventData)
        {
            //跟随鼠标
            transform.position = eventData.position;
        }
        public void ItemOnRun()
        {
            tragger.SetActive(true);
        }
    }
}