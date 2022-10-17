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
    public GameObject Player;
    public string what;
    void Start()
    {
        Player = GameObject.Find("Player");
        //获取按钮组件
        Button button = GetComponent<Button>();
        //往按钮的点击事件添加方法
        button.onClick.AddListener(Click0);
        button.onClick.AddListener(Click1);
    }

    public void Click1()
    {
        //发送
        issent = true;
        //找到第一个信箱并使它具有信
        GameObject.FindWithTag("mailbox").GetComponent<MailBoxManager>().ishave = true;
        //使信隐藏
        myLetter.SetActive(false);
    }
    //给词条管理器赋值
    public void Click0()
    {
        for (int i = 0; i < gameObject.transform.parent.childCount-1; i++)
        {
            //判断规律还是行动
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
            case 0://主语
                switch (what)
                {
                    case "cabinets": Player.GetComponent<PlayerController>().cabinets = true; break;
                    case "hospital": Player.GetComponent<PlayerController>().hospital = true; break;
                    case "HRM": Player.GetComponent<PlayerController>().HRM = true; break;
                    case "illness": Player.GetComponent<PlayerController>().illness_bad = true; break;
                    case "pharmacy": Player.GetComponent<PlayerController>().pharmacy_bad = true; break;
                    case "TCM": Player.GetComponent<PlayerController>().TCM = true; break;
                    default: break;
                };
                break;
            case 1://谓语
                switch (what)
                {
                    case "shi": Player.GetComponent<PlayerController>().shi= true; break;
                        default : break;
                };
                break;
            case 2://宾语
                switch(what)
                {
                    case "bad": Player.GetComponent<PlayerController>().bad= true; break;
                    case "good": Player.GetComponent<PlayerController>().good= true; break;
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
            case 0://谓语
                switch (what)
                {
                    case "avoid": Player.GetComponent<PlayerController>().avoid= true; break;
                    case "eat": Player.GetComponent<PlayerController>().eat= true; break;
                    case "entry": Player.GetComponent<PlayerController>().entry= true; break;
                    case "exercise": Player.GetComponent<PlayerController>().exercise= true; break;
                    case "relax": Player.GetComponent<PlayerController>().relax = true; break;
                    default: break;
                };
                break;
            case 1://宾语
                switch (what)
                {
                    case "cabinets": Player.GetComponent<PlayerController>().cabinets = true; break;
                    case "hospital": Player.GetComponent<PlayerController>().hospital = true; break;
                    case "HRM": Player.GetComponent<PlayerController>().HRM = true; break;
                    case "illness": Player.GetComponent<PlayerController>().illness_avoid = true; break;
                    case "pharmacy": Player.GetComponent<PlayerController>().pharmacy_avoid = true; break;
                    case "TCM": Player.GetComponent<PlayerController>().TCM = true; break;
                    default: break;
                };
                break;
            default: break;
        }
    }
}
