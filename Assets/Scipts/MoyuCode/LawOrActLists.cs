using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class LawOrActLists : MonoBehaviour
{
    public List<CitiaoClass > CitiaoInlawlists=new List<CitiaoClass>() ;
    public List<CitiaoClass > CitiaoInActLists=new List<CitiaoClass>() ;
    public CitiaoClass[] citiaoClassesLaw;
    public CitiaoClass[] citiaoClassesAct;
    public int LawNum;
    public int ActNum; 
    public void RemoveLaw(int i)
    {
        CitiaoInlawlists.RemoveRange(i,3);
    }
    public void RemoveAct(int i)
    {
        CitiaoInActLists.RemoveRange(i,2);
    }
    public virtual void OnLaw()
    {

    }
    public virtual void OnAct()
    {

    }
}
