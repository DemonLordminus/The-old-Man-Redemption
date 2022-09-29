using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class WordInstanceInfo : MonoBehaviour
{
    public WordScrObj wordDataFather;//从scrObj读取数据

    private Text TextDisplay;//显示文字组件

    public string wordDisplay;//显示在面板上的文字
    public List<wordT> wordTypeList;
    public wordM wordMeaning;

    public bool isGetData;//记录是否成功获取数据 后续可以考虑删除

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
    } //从ScrObj获得数据

    [EditorButton]
    public void WordDataUpdata()
    {
        TextDisplay = GetComponentInChildren<Text>();
        isGetData = GetDataFromScrObj();
        TextDisplay.text = wordDisplay;
    }

    //拖拽模块 还是新脚本吧 写在同一个脚本确实有点不方便
    #region
    ////[HideInInspector]
    //public bool isdrag=false;//检测是否被拖拽
    //private void OnMouseDown()
    //{
    //    isdrag = true; 
    //}

    #endregion
}
