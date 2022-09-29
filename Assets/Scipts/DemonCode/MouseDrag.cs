using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseDrag : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public bool isDrag;
    public bool isPreview;
    [SerializeField]
    public Canvas canvas;
    private Vector2 scaleOri, scalePre;
    public float PreviewPower;//�Ŵ���


    ///public Transform orignaParent;
    private void Update()
    {
       

    }

    private void OnMouseEnter()
    {
        isPreview = true;
        scaleOri = transform.localScale;
        scalePre = new Vector2(PreviewPower * scaleOri.x, PreviewPower * scaleOri.y);
        transform.localScale = scalePre;
    }
    private void OnMouseExit()
    {
        isPreview = false;
        transform.localScale = scaleOri;
    }

    #region 
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            isDrag = true;
            if (canvas != null)
            {
                ++canvas.sortingOrder;
            }
            ///orignaParent = transform.parent;//ȷ����ʼ���ڵ�
            ///transform.SetParent(transform.parent.parent);//�ı丸�ڵ�
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (isDrag || eventData.button == PointerEventData.InputButton.Left)
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(cursorPos.x, cursorPos.y);
            
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (canvas != null)
            {
                --canvas.sortingOrder;
            }
            isDrag = false;
           /// transform.SetParent(orignaParent);//�ָ����ڵ�
           /// 
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("OnPointerClick");//���Ҽ����ᴥ��
        //if (eventData.button == PointerEventData.InputButton.Left)
        //{
        //    if (!isDrag)
        //    {
        //        Debug.Log("��ס������");
        //        isDrag = true;

        //    }
        //}
    }
    #endregion
}
