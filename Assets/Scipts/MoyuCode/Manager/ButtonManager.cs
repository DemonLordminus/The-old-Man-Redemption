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
        //��ȡ��ť���
        Button button = GetComponent<Button>();
        //����ť�ĵ���¼����ӷ���
        button.onClick.AddListener(Click1);
    }

    public void Click1()
    {
        //����
        issent = true;
        //�ҵ���һ�����䲢ʹ��������
        GameObject.FindWithTag("mailbox").GetComponent<MailBoxManager>().ishave = true;
        //ʹ������
        myLetter.SetActive(false);
    }
}