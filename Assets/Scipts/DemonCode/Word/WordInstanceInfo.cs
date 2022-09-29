using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class WordInstanceInfo : MonoBehaviour
{
    public WordScrObj wordDataFather;//��scrObj��ȡ����

    private Text TextDisplay;//��ʾ�������

    public string wordDisplay;//��ʾ������ϵ�����
    public List<wordT> wordTypeList;
    public wordM wordMeaning;

    public bool isGetData;//��¼�Ƿ�ɹ���ȡ���� �������Կ���ɾ��

    // Start is called before the first frame update
    void Start()
    {
        if (wordDataFather != null)
        {
            WordDataUpdata();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool GetDataFromScrObj()
    {
        if (wordDataFather == null)
        {
            return false;
        }
        else 
        {
            wordDisplay = wordDataFather.wordDisplay;
            wordMeaning = wordDataFather.wordMeaning;
            wordTypeList = wordDataFather.wordTypeList;

            return true;
        }
    } //��ScrObj�������

    [EditorButton]
    public void WordDataUpdata()
    {
        TextDisplay = GetComponentInChildren<Text>();
        isGetData = GetDataFromScrObj();
        TextDisplay.text = wordDisplay;
    }

    //��קģ�� �����½ű��� д��ͬһ���ű�ȷʵ�е㲻����
    #region
    ////[HideInInspector]
    //public bool isdrag=false;//����Ƿ���ק
    //private void OnMouseDown()
    //{
    //    isdrag = true; 
    //}

    #endregion
}
