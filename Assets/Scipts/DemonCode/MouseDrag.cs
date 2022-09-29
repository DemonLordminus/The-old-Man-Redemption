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
    public float PreviewPower;//放大倍率


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
            ///orignaParent = transform.parent;//确定初始父节点
            ///transform.SetParent(transform.parent.parent);//改变父节点
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
           /// transform.SetParent(orignaParent);//恢复父节点
           /// 
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("OnPointerClick");//左右键都会触发
        //if (eventData.button == PointerEventData.InputButton.Left)
        //{
        //    if (!isDrag)
        //    {
        //        Debug.Log("按住鼠标左键");
        //        isDrag = true;

        //    }
        //}
    }
    #endregion
}
