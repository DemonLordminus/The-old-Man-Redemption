using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum wordT //即wordType
{ 
    front,//主谓宾不会 英文太烦 这样写吧
    mid,
    back,
}

public enum wordM //wordMeaning 文字的具体含义 目前用的是枚举 其实字符串也行
{ 
    danger,//危险
    safe,
    monster,
    hero,//名词 主角 但不用player
    _is,

}

//public class WordInfo //文字类
//{
//    private wordType wt;
//    private wordMeaning wm;
//    private string wordDisplay;

//    WordInfo(wordMeaning _wm) //构造函数
//    {
//        wm = _wm;
//        switch (wm)
//        { 
            
        
//        }
//    }
//}