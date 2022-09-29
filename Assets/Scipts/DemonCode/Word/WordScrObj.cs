using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Towards老师传承的ScrObj 感谢
[CreateAssetMenu(fileName = "NewWord", menuName = "ScriptableObjects/WordScrObj", order = 1)]
public class WordScrObj : ScriptableObject
{
    public List<wordT> wordTypeList;
    public wordM wordMeaning;
    public string wordDisplay;


}
