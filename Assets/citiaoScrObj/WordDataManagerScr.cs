using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WordDataManagerScr", menuName = "Inventory/WordDataManagerScr")]
public class WordDataManagerScr : ScriptableObject
{
    public List<ScrObjcitiao> eventElementWordList;
    public List<ScrObjcitiao> lifeSytleWordList;
    public List<ScrObjcitiao> verbWordList;
    public List<ScrObjcitiao> isWordList;
    public List<ScrObjcitiao> goodOrBadWordList;

    public void wordSerialNumGive()
    {
        int i = 0;
        foreach (ScrObjcitiao citiaoScr in eventElementWordList)
        {
            citiaoScr.serialNum = i++;
        }
        foreach (ScrObjcitiao citiaoScr in lifeSytleWordList)
        {
            citiaoScr.serialNum = i++;
        }
        foreach (ScrObjcitiao citiaoScr in verbWordList)
        {
            citiaoScr.serialNum = i++;
        }
        foreach (ScrObjcitiao citiaoScr in isWordList)
        {
            citiaoScr.serialNum = i++;
        }
        foreach (ScrObjcitiao citiaoScr in goodOrBadWordList)
        {
            citiaoScr.serialNum = i++;
        }
    }
}

