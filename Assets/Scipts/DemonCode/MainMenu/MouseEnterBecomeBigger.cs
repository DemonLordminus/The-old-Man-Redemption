using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseEnterBecomeBigger : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool isPreview;
    private Vector3 scaleOri, scalePre;
    public float PreviewPower;//·Å´ó±¶ÂÊ

    public void OnPointerEnter(PointerEventData eventData)
    {
        isPreview = true;
        scaleOri = transform.localScale;
        scalePre = new Vector3(PreviewPower * scaleOri.x, PreviewPower * scaleOri.y,1);
        transform.localScale = scalePre;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        isPreview = false;
        transform.localScale = scaleOri;
    }
}
