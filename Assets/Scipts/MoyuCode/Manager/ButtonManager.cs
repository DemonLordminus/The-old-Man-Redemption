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
                    case "cabinets": Player.GetComponent<PlayerController>().citiaos[2] = true; break;
                    case "hospital": Player.GetComponent<PlayerController>().citiaos[8] = true; break;
                    case "HRM": Player.GetComponent<PlayerController>().citiaos[10] = true; break;
                    case "illness": Player.GetComponent<PlayerController>().citiaos[12] = true; break;
                    case "pharmacy": Player.GetComponent<PlayerController>().citiaos[14] = true; break;
                    case "TCM": Player.GetComponent<PlayerController>().citiaos[18] = true; break;
                    default: break;
                };
                break;
            case 1://谓语
                switch (what)
                {
                    case "shi": Player.GetComponent<PlayerController>().citiaos[17] = true; break;
                        default : break;
                };
                break;
            case 2://宾语
                switch(what)
                {
                    case "bad": Player.GetComponent<PlayerController>().citiaos[1] = true; break;
                    case "good": Player.GetComponent<PlayerController>().citiaos[7] = true; break;
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
                    case "avoid": Player.GetComponent<PlayerController>().citiaos[0] = true; break;
                    case "eat": Player.GetComponent<PlayerController>().citiaos[4] = true; break;
                    case "entry": Player.GetComponent<PlayerController>().citiaos[5] = true; break;
                    case "exercise": Player.GetComponent<PlayerController>().citiaos[6] = true; break;
                    case "relax": Player.GetComponent<PlayerController>().citiaos[16] = true; break;
                    default: break;
                };
                break;
            case 1://宾语
                switch (what)
                {
                    case "cabinets": Player.GetComponent<PlayerController>().citiaos[3] = true; break;
                    case "hospital": Player.GetComponent<PlayerController>().citiaos[9] = true; break;
                    case "HRM": Player.GetComponent<PlayerController>().citiaos[11] = true; break;
                    case "illness": Player.GetComponent<PlayerController>().citiaos[13] = true; break;
                    case "pharmacy": Player.GetComponent<PlayerController>().citiaos[15] = true; break;
                    case "TCM": Player.GetComponent<PlayerController>().citiaos[19] = true; break;
                    default: break;
                };
                break;
            default: break;
        }
    }
}
