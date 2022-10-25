using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//声明词条的类
public class citiao : MonoBehaviour
{
    public ScrObjcitiao citiaoScrObj;
    [HideInInspector]
    public string citiaoName;
    [HideInInspector]
    public Sprite image;
    public TextMeshProUGUI textShow;
    private void Start()
    {
        if (citiaoScrObj != null)
        {
            citiaoName = citiaoScrObj.name;
            //int r = Random.Range(0,citiaoScrObj.Image.Length);
           //image = citiaoScrObj.Image[r];
           // gameObject.transform.GetChild(1).GetComponent<Image>().sprite = image;
        }
        else 
        {
            Debug.LogWarning("兄弟，你没设置ScrObj");
        }
    }
}
