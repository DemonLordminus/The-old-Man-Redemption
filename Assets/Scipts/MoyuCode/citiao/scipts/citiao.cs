using System.Collections;
using System.Collections.Generic;
//using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;
//������������
public class citiao : MonoBehaviour
{
    public ScrObjcitiao citiaoScrObj;
    [HideInInspector]
    public string citiaoName;
    [HideInInspector]
    public Sprite image;
    private void Start()
    {
        if (citiaoScrObj != null)
        {
            citiaoName = citiaoScrObj.name;
            int r = Random.Range(0,citiaoScrObj.Image.Length);
            image = citiaoScrObj.Image[r];
            gameObject.transform.GetChild(1).GetComponent<Image>().sprite = image;
        }
        else 
        {
            Debug.LogWarning("�ֵܣ���û����ScrObj");
        }
    }
}
