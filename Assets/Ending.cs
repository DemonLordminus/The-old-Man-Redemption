using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Ending : MonoBehaviour
{
    public GameObject end;
    public bool isRun;
    private void OnEnable()
    {
        isRun = true;
        time = 0f;
        timer = 0f;
        onJuqing = true;
        onEnd = false;
        onEvent = false;
        end.GetComponent<TextMeshProUGUI>().text = "剧情事件" + "\n";
    }
    public float time;
    public float timer;
    public float timer1;
    public int num;
    public bool onJuqing;
    public bool onEnd;
    public bool onEvent;
    private void Update()
    {
        timer += Time.deltaTime;
        if (isRun && timer - time > 0.5f)
        {
            time = timer;
            if (num < DataManager.instance.JuQingFinishin.Count && onJuqing)
            {
                end.GetComponent<TextMeshProUGUI>().text += DataManager.instance.JuQingFinishin[num] + "\n";
                num++;
            }
            if (num == DataManager.instance.JuQingFinishin.Count && onJuqing)
            {
                end.GetComponent<TextMeshProUGUI>().text += "事件回顾" + "\n";
                num = 0;
                onEnd = true;
                onJuqing = false;
            }
            if (onEnd && num < DataManager.instance.endFinishin.Count)
            {
                end.GetComponent<TextMeshProUGUI>().text += DataManager.instance.endFinishin[num] + "\n";
                num++;
            }
            if (num == DataManager.instance.endFinishin.Count && onEnd)
            {
                num = 0;
                onEvent = true;
                onEnd = false;
            }
            if (onEvent && num < DataManager.instance.eventFinishing.Count)
            {
                end.GetComponent<TextMeshProUGUI>().text += DataManager.instance.eventFinishing[num] + "\n";
                num++;
            }
            if (onEvent && num == DataManager.instance.eventFinishing.Count &&time-timer1>5f)
            {
                if (DataManager.instance.controller.gameover)
                {
                    SceneManager.LoadScene("Gameover");
                }
                else
                {
                    SceneManager.LoadScene("StartMenu");
                }
            }
            if(time-timer1>4f)
            {
                timer1 = time;
            }
        }

    }
}