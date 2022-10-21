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
    void Start()
    {
        //获取按钮组件
        Button button = GetComponent<Button>();
        //往按钮的点击事件添加方法
        button.onClick.AddListener(Click0);
    }
    #region old
    /*public void Click1()
    {
        //发送
        issent = true;
        //找到第一个信箱并使它具有信
        GameObject.Find("mailbox").GetComponent<MailboxEvent>().ishave = true;
        //使信隐藏
        myLetter.SetActive(false);
    }*/
    //给词条管理器赋值
    #endregion
    public void Click0()
    {
        //找到第一个信箱并使它具有信
        GameObject.Find("mailbox").GetComponent<MailboxEvent>().ishave = true;
        //使信隐藏
        myLetter.SetActive(false);
        for (int i = 0; i < gameObject.transform.parent.childCount-1; i++)
        {
            //判断规律还是行动
            lawOrAct = false;
            for (int j = 0; j < gameObject.transform.parent.GetChild(i).childCount; j++)
            {
                if (gameObject.transform.parent.GetChild(i).GetChild(j).GetComponent<citiao>().citiaoScrObj.type == (wordType)2)
                {
                    lawOrAct = true;
                    break;
                }
            }
            if (lawOrAct && gameObject.transform.parent.GetChild(i).childCount == 3)
            {
                citiao = new string[3];
                for (int k = 0; k < 3; k++)
                {
                    AssignmentLaw(i, k);
                    if (citiao[k] == null)
                    {
                        return;
                    }
                }

                LawOrActLists.lawlists.Add(citiao[0] + citiao[1] + citiao[2]);

            }
            if (!lawOrAct && gameObject.transform.parent.GetChild(i).childCount <= 2)
            {
                citiao = new string[2];
                for (int k = 0; k < gameObject.transform.parent.GetChild(i).childCount; k++)
                {
                    AssignmentAct(i, k);
                    if (citiao[k] == null)
                    {
                        return;
                    }
                }
                LawOrActLists.ActLists.Add(citiao[0] + citiao[i]);
            }
        }
    }
    public string[] citiao;
    public void AssignmentLaw(int i, int k)
    {
        ScrObjcitiao = gameObject.transform.parent.GetChild(i).GetChild(k).gameObject.GetComponent<citiao>().citiaoScrObj;
        switch (k)
        {
            case 0://主语
                #region 旧日
                /*switch (what)
                {
                    case "cabinets": citiao[k]=new CitiaoClass(whatNo); break;
                    case "hospital": Player.GetComponent<PlayerController>().citiaos[8] = true; break;
                    case "HRM": Player.GetComponent<PlayerController>().citiaos[10] = true; break;
                    case "illness": Player.GetComponent<PlayerController>().citiaos[12] = true; break;
                    case "pharmacy": Player.GetComponent<PlayerController>().citiaos[14] = true; break;
                    case "TCM": Player.GetComponent<PlayerController>().citiaos[18] = true; break;
                    default: break;
                };*/
                /*if(what== "cabinets"||what == "hospital"||what== "HRM"||what =="illness"||what=="pharmacy"||what =="TCM")
                {
                    citiao[k] = new CitiaoClass(whatNo);
                }
                break;*/
                #endregion
                if (ScrObjcitiao.type == (wordType)0)
                {
                    citiao[k] = ScrObjcitiao.Content;
                }
                break;
            case 1://谓语
                #region 旧日
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
            case 2://宾语
                #region 旧日
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
        ScrObjcitiao = gameObject.transform.parent.GetChild(i).GetChild(k).gameObject.GetComponent<citiao>().citiaoScrObj;
        switch (k)
        {
            case 0://谓语
                #region 旧日
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
            case 1://宾语
                #region 旧日
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
