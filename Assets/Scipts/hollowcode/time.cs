using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class time : MonoBehaviour
{
    public void stopgame()
    {
        Time.timeScale = 0f;
    }
    public void begin()
    {
        Time.timeScale = 1f;
    }
}
