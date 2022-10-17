using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InkManager : MonoBehaviour
{
    public bool ifUseInk;
    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(Click);
    }
    public void Click()
    {
        ifUseInk = true;
    }
}
