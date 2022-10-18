using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public Texture2D ink, normal;
    public bool ifUseInk;
    void Start()
    {
        Cursor.SetCursor(normal, new Vector2(0, 0), CursorMode.Auto);
    }
    private void Update()
    {
        ifUseInk = GameObject.Find("Ink").GetComponent<InkManager>().ifUseInk;
        if(ifUseInk)
        {
            Cursor.SetCursor(ink, new Vector2(16, 16), CursorMode.Auto);
        }
        else
        {
            Cursor.SetCursor(normal, new Vector2(0, 0), CursorMode.Auto); //∏ƒŒ™0£¨0   ≈‰÷∏’Î
        }
    }

}
