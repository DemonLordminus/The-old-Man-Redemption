using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public InkManager inkM;
    public Texture2D ink, normal;
    public bool ifUseInk;
    void Start()
    {
        Cursor.SetCursor(normal, new Vector2(0, 0), CursorMode.Auto);
    }
    private void Update() //这一堆不好 迟早要改
    {
        if (inkM != null)
        {
            ifUseInk = inkM.GetComponent<InkManager>().ifUseInk;
            if (ifUseInk)
            {
                Cursor.SetCursor(ink, new Vector2(16, 16), CursorMode.Auto);
            }
            else
            {
                Cursor.SetCursor(normal, new Vector2(0, 0), CursorMode.Auto); //改为0，0 适配指针
            }
        }
    }

}
