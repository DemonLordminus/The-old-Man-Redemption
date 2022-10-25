using Cinemachine;
using Dmld;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//��������Ʒ��ʹ�ã���ק����������Ч
namespace tur
{
    public class ItemOnDragForTurtorial : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        //������ʼ����
        public Transform originalParent;
        public GetItem GetItem;
        public GameObject traggerManager;
        public GameObject tragger;
        public int count1 = 0;
        public float kangshengsu = 5;
        public float swyl;//ʳ�����ϵĻظ���
        public PlayerControlForTurtorial playerController;
        public CinemachineVirtualCamera virtualCamera;//����Ķ���������
        private void Start()
        {
            //playerController = DataManager.instance.controller;
            traggerManager = GameObject.Find("TraggerManager");
            GetItem = this.gameObject.GetComponent<Item>().itemname;
        }
        //���������
        public void OnBeginDrag(PointerEventData eventData)
        {
            //��ʼ������ֵ
            originalParent = transform.parent;
            //������������
            //transform.SetParent(transform.parent.parent);
            //��������ƶ�
            transform.position = eventData.position;
            //�޸����������ԣ���ֹ�������ߴ�͸
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
        //����ɿ���ק����
        public void OnEndDrag(PointerEventData eventData)
        {
            Vector3 vector = Input.mousePosition - gameObject.transform.parent.transform.position;
            Debug.Log(vector.x);
            int delta = (int)vector.x;
            try
            {
                if (delta < 0)//��������ȡ�������������ײ�������ͼ��     //citiao����λ��
                {
                    //ʹ��ק����鵽��굱ǰλ�õĿ���
                    transform.position = eventData.position;
                    //SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent);
                    //transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
                    //ʹԭ�ж��󷵻ص���ק�����ԭʼλ��
                    //eventData.pointerCurrentRaycast.gameObject.transform.position = originalParent.position;
                    //eventData.pointerCurrentRaycast.gameObject.transform.SetParent(originalParent);
                    GetComponent<CanvasGroup>().blocksRaycasts = true;
                    return;//�˳�
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
        //�����ק����
        public void OnDrag(PointerEventData eventData)
        {
            //�������
            transform.position = eventData.position;
        }
        public void ItemOnRun()
        {
            tragger.SetActive(true);
        }
    }
}