using Dmld;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class LawOrActLists : MonoBehaviour
{
    public List<string> lawlists=new List<string>() ;
    public List<string > ActLists=new List<string>() ;
    public List <string> HealthyLawLists=new List<string>() ;
    public List<DebuffClass> debuffClasses=new List<DebuffClass>();
    public bool OnLaw(string LawName)
    {
        for (int i = 0; i < lawlists.Count; i ++)
        {
            if (lawlists[i]  == LawName)
            {
                return true;
            }
        }
        return false;
    }
    public bool OnAct(string ActName)
    {
        for (int i = 0; i < ActLists.Count; i ++)
        {
            if (lawlists[i]  == ActName)
            {
                ActLists.RemoveAt(i);
                return true;
            }
        }
        return false;
    }
}
