using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject myLetter;
    public bool issent;
    public bool lawOrAct;
    public GameObject CitiaoManager;
    public string what;
    void Start()
    {
        CitiaoManager = GameObject.Find("CitiaoManager");
        //��ȡ��ť���
        Button button = GetComponent<Button>();
        //����ť�ĵ���¼���ӷ���
        button.onClick.AddListener(Click0);
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
    //��������������ֵ
    public void Click0()
    {
        for (int i = 0; i < gameObject.transform.parent.childCount; i++)
        {
            //�жϹ��ɻ����ж�
            lawOrAct = false;
            for (int j = 0; j < gameObject.transform.parent.GetChild(i).childCount; j++)
            {
                if (gameObject.transform.parent.GetChild(i).GetChild(j).GetComponent<citiao>().citiaoName.Name == "shi")
                {
                    lawOrAct = true;
                    break;
                }
            }
            if (lawOrAct && gameObject.transform.parent.GetChild(i).childCount == 3)
            {
                for (int k = 0; k < 3; k++)
                {
                    AssignmentLaw(i, k);
                }
            }
            if(!lawOrAct&&gameObject.transform.parent.GetChild(i).childCount<=2)
            {
                for(int k=0; k < gameObject.transform.parent.GetChild(i).childCount; k++)
                {
                    AssignmentAct(i, k);
                }
            }

        }
    }
    public void AssignmentLaw(int i, int k)
    {
        what = gameObject.transform.parent.GetChild(i).GetChild(k).gameObject.GetComponent<CitiaoControllor>().what;
        switch (k)
        {
            case 0://����
                switch (what)
                {
                    case "cabinets": CitiaoManager.GetComponent<CitiaoManager>().cabinets = true; break;
                    case "hospital": CitiaoManager.GetComponent<CitiaoManager>().hospital = true; break;
                    case "HRM": CitiaoManager.GetComponent<CitiaoManager>().HRM = true; break;
                    case "illness": CitiaoManager.GetComponent<CitiaoManager>().illness = true; break;
                    case "pharmacy": CitiaoManager.GetComponent<CitiaoManager>().pharmacy = true; break;
                    case "TCM": CitiaoManager.GetComponent<CitiaoManager>().TCM = true; break;
                    default: break;
                };
                break;
            case 1://ν��
                switch (what)
                {
                    case "shi": CitiaoManager.GetComponent<CitiaoManager>().shi= true; break;
                        default : break;
                };
                break;
            case 2://����
                switch(what)
                {
                    case "bad": CitiaoManager.GetComponent<CitiaoManager>().bad= true; break;
                    case "good": CitiaoManager.GetComponent<CitiaoManager>().good= true; break;
                    default:break;
                };
                break;
            default:break;
        }
    }
    public void AssignmentAct(int i, int k)
    {
        what = gameObject.transform.parent.GetChild(i).GetChild(k).gameObject.GetComponent<CitiaoControllor>().what;
        switch (k)
        {
            case 0://ν��
                switch (what)
                {
                    case "avoid": CitiaoManager.GetComponent<CitiaoManager>().avoid= true; break;
                    case "eat": CitiaoManager.GetComponent<CitiaoManager>().eat= true; break;
                    case "entry": CitiaoManager.GetComponent<CitiaoManager>().entry= true; break;
                    case "exercise": CitiaoManager.GetComponent<CitiaoManager>().exercise= true; break;
                    case "relax": CitiaoManager.GetComponent<CitiaoManager>().relax = true; break;
                    default: break;
                };
                break;
            case 1://����
                switch (what)
                {
                    case "cabinets": CitiaoManager.GetComponent<CitiaoManager>().cabinets = true; break;
                    case "hospital": CitiaoManager.GetComponent<CitiaoManager>().hospital = true; break;
                    case "HRM": CitiaoManager.GetComponent<CitiaoManager>().HRM = true; break;
                    case "illness": CitiaoManager.GetComponent<CitiaoManager>().illness = true; break;
                    case "pharmacy": CitiaoManager.GetComponent<CitiaoManager>().pharmacy = true; break;
                    case "TCM": CitiaoManager.GetComponent<CitiaoManager>().TCM = true; break;
                    default: break;
                };
                break;
            default: break;
        }
    }
}
