using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Close : MonoBehaviour
{
    void Start()
    {
        //获取按钮组件
        Button button = GetComponent<Button>();
        //往按钮的点击事件添加方法
        button.onClick.AddListener(Click1);
    }

    public void Click1()
    {
        Time.timeScale = 1f;
    }
}
