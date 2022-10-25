using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Ending : MonoBehaviour
{
    public bool isRun;
    private void OnEnable()
    {
        isRun = true;
        time = 0f;
        timer = 0f;
        onEnd = false;
        onEvent = false;
        GameObject.Find("End").GetComponent<TextMeshPro>().text = "剧情事件" + "\n";
    }
    public float time;
    public float timer;
    public int num;
    public bool onEnd;
    public bool onEvent;
    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if(isRun&&timer-time>1.5f)
        {
            if (timer > 1.5f)
            {
                time = timer;
            }
            if (num < DataManager.instance.JuQingFinishin.Count)
            {
                GameObject.Find("End").GetComponent<TextMeshPro>().text += DataManager.instance.JuQingFinishin[num]+"\n";
                num++;
            }
            if(num ==DataManager.instance.JuQingFinishin.Count)
            {
                GameObject.Find("End").GetComponent<TextMeshPro>().text += "事件回顾" + "\n";
                num = 0;
                onEnd = true;
            }
            if(onEnd&&num <DataManager.instance.endFinishin.Count)
            {
                GameObject.Find("End").GetComponent<TextMeshPro>().text += DataManager.instance.endFinishin[num] + "\n";
                num++;
            }
            if (num == DataManager.instance.endFinishin.Count&&onEnd)
            {
                num = 0;
                onEvent = true;
            }
            if(onEvent&&num<DataManager.instance.eventFinishing.Count)
            {
                GameObject.Find("End").GetComponent<TextMeshPro>().text += DataManager.instance.eventFinishing[num] + "\n";
                num++;
            }
            if(onEvent&&num== DataManager.instance.eventFinishing.Count)
            {
                if(DataManager.instance.controller.gameover)
                {
                    SceneManager.LoadScene("Gameover");
                }
                else
                {
                    SceneManager.LoadScene("EndScene");
                }
            }
        }
    }
}
