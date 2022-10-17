using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseManager : MonoBehaviour
{
    public Texture2D ink;
    public bool ifUse;
    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(Click);
    }
    public void Click()
    {
        Cursor.SetCursor(ink,new Vector2(16,16),CursorMode.Auto);
        ifUse = true;
    }
}
