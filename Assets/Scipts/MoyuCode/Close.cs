using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Close : MonoBehaviour
{
    void Start()
    {
        //��ȡ��ť���
        Button button = GetComponent<Button>();
        //����ť�ĵ���¼���ӷ���
        button.onClick.AddListener(Click1);
    }

    public void Click1()
    {
        Time.timeScale = 1f;
    }
}
