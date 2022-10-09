using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject myLetter;
    public bool issent;
    void Start()
    {
        //获取按钮组件
        Button button = GetComponent<Button>();
        //往按钮的点击事件添加方法
        button.onClick.AddListener(Click1);
    }

    public void Click1()
    {
        issent = true;
        GameObject.FindWithTag("mailbox").GetComponent<MailBoxManager>().ishave = true;
        myLetter.SetActive(false);
    }
}
