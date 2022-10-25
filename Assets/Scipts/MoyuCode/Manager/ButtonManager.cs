using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject myLetter;
    public bool lawOrAct;
    public ScrObjcitiao ScrObjcitiao;
    public LawOrActLists LawOrActLists;
    public int citiaoNum;
    void Start()
    {
        //��ȡ��ť���
        Button button = GetComponent<Button>();
        //����ť�ĵ���¼���ӷ���
        button.onClick.AddListener(Click0);
    }
    #region old
    /*public void Click1()
    {
        //����
        issent = true;
        //�ҵ���һ�����䲢ʹ��������
        GameObject.Find("mailbox").GetComponent<MailboxEvent>().ishave = true;
        //ʹ������
        myLetter.SetActive(false);
    }*/
    //��������������ֵ
    #endregion
    public void Click0()
    {
        //�ҵ���һ�����䲢ʹ��������
        //GameObject.Find("mailbox").GetComponent<MailboxEvent>().ishave = true;
        //ʹ������
        myLetter.SetActive(false);
        DataManager.instance.controller.Isrun = true;
        for (int i = 0; i < gameObject.transform.parent.childCount-1; i++)
        {
            citiaon = "";
            citiaoNum = 0;
            citiaoNo = new int[3];
            //�жϹ��ɻ����ж�
            lawOrAct = false;
            for (int j = 0; j < 3; j++)
            {
                try
                {
                    if (gameObject.transform.parent.GetChild(i).GetChild(j).GetChild(0) != null)
                    { }
                    citiaoNo[citiaoNum] = j;
                    citiaoNum++;
                    if (gameObject.transform.parent.GetChild(i).GetChild(j).GetChild(0).GetComponent<citiao>().citiaoScrObj.type == (wordType)2)
                    {
                        lawOrAct = true;
                    }
                }
                catch
                { }
            }
            Debug.Log("����" + citiaoNum);
            if (lawOrAct && citiaoNum == 3)
            {
                Debug.Log("����"+citiaoNum);
                citiao = new string[3];
                for (int k = 0; k < 3; k++)
                {
                    AssignmentLaw(i, k);
                    if (citiao[k] == null)
                    {
                        return;
                    }
                    citiaon+=citiao[k];
                }
                LawOrActLists.lawlists.Add(citiaon);

            }
            if (!lawOrAct && citiaoNum <= 2)
            {
                citiao = new string[2];
                for (int k = 0; k < citiaoNum; k++)
                {
                    AssignmentAct(i, k);
                    if (citiao[k] == null)
                    {
                        return;
                    }
                    citiaon+= citiao[k] ;
                }
                LawOrActLists.ActLists.Add(citiaon);
            }
        }

    }
    public string citiaon;
    public string[] citiao;
    public int[] citiaoNo;
    public void AssignmentLaw(int i, int k)
    {
        ScrObjcitiao = gameObject.transform.parent.GetChild(i).GetChild(citiaoNo[k]).GetChild(0).gameObject.GetComponent<citiao>().citiaoScrObj;
        switch (k)
        {
            case 0://����
                #region ����
                /*switch (what)
                {
                    case "cabinets": citiao[k]=new ItemClass(whatNo); break;
                    case "hospital": Player.GetComponent<PlayerController>().citiaos[8] = true; break;
                    case "HRM": Player.GetComponent<PlayerController>().citiaos[10] = true; break;
                    case "illness": Player.GetComponent<PlayerController>().citiaos[12] = true; break;
                    case "pharmacy": Player.GetComponent<PlayerController>().citiaos[14] = true; break;
                    case "TCM": Player.GetComponent<PlayerController>().citiaos[18] = true; break;
                    default: break;
                };*/
                /*if(what== "cabinets"||what == "hospital"||what== "HRM"||what =="illness"||what=="pharmacy"||what =="TCM")
                {
                    citiao[k] = new ItemClass(whatNo);
                }
                break;*/
                #endregion
                if (ScrObjcitiao.type == (wordType)0)
                {
                    citiao[k] = ScrObjcitiao.Content;
                }
                break;
            case 1://ν��
                #region ����
                /*switch (what)
                {
                    case "shi": Player.GetComponent<PlayerController>().citiaos[17] = true; break;
                        default : break;
                };*/
                #endregion
                if (ScrObjcitiao.type == (wordType)2)
                {
                    citiao[k] = ScrObjcitiao.Content;
                }
                break;
            case 2://����
                #region ����
                /*switch(what)
                {
                    case "bad": Player.GetComponent<PlayerController>().citiaos[1] = true; break;
                    case "good": Player.GetComponent<PlayerController>().citiaos[7] = true; break;
                    default:break;
                };*/
                #endregion
                if (ScrObjcitiao.type == (wordType)4)
                {
                    citiao[k] = ScrObjcitiao.Content;
                }
                break;
            default: break;
        }
    }
    public void AssignmentAct(int i, int k)
    {
        ScrObjcitiao = gameObject.transform.parent.GetChild(i).GetChild(citiaoNo[k]).GetChild(0).gameObject.GetComponent<citiao>().citiaoScrObj;
        switch (k)
        {
            case 0://ν��
                #region ����
                /*switch (what)
                {
                    case "avoid": Player.GetComponent<PlayerController>().citiaos[0] = true; break;
                    case "eat": Player.GetComponent<PlayerController>().citiaos[4] = true; break;
                    case "entry": Player.GetComponent<PlayerController>().citiaos[5] = true; break;
                    case "exercise": Player.GetComponent<PlayerController>().citiaos[6] = true; break;
                    case "relax": Player.GetComponent<PlayerController>().citiaos[16] = true; break;
                    default: break;
                };*/
                #endregion
                if (ScrObjcitiao.type == (wordType)3)
                {
                    citiao[k] = ScrObjcitiao.Content;
                }
                break;
            case 1://����
                #region ����
                /*switch (what)
                {
                    case "cabinets": Player.GetComponent<PlayerController>().citiaos[3] = true; break;
                    case "hospital": Player.GetComponent<PlayerController>().citiaos[9] = true; break;
                    case "HRM": Player.GetComponent<PlayerController>().citiaos[11] = true; break;
                    case "illness": Player.GetComponent<PlayerController>().citiaos[13] = true; break;
                    case "pharmacy": Player.GetComponent<PlayerController>().citiaos[15] = true; break;
                    case "TCM": Player.GetComponent<PlayerController>().citiaos[19] = true; break;
                    default: break;
                };*/
                #endregion
                if (ScrObjcitiao.type == (wordType)0)
                {
                    citiao[k] = ScrObjcitiao.Content;
                }
                break;
            default: break;
        }
    }
}
