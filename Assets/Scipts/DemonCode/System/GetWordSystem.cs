using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWordSystem : MonoBehaviour
{
    [SerializeField]
    public GameObject wordPrefeb;
    [SerializeField]
    public GameObject wordFather;
    [SerializeField]
    public GameObject wordCreateArea;


    [SerializeField]
    public List<WordScrObj> scriptableObjects;

    public WordScrObj getTargrtTest;


    void createWord(WordScrObj wordScr)
    {
        if (wordPrefeb == null)
        {
            wordPrefeb = GameObject.Find("Word Prefebs");
        }
        var wordIns = Instantiate(wordPrefeb, wordFather.transform);
        var wordInfo = wordIns.GetComponent<WordInstanceInfo>();
        wordInfo.wordDataFather = wordScr;
        wordInfo.WordDataUpdata();
        wordInfo.transform.position = wordCreateArea.transform.position;
    
    }
    [EditorButton]
    void createWord()
    {
        if (wordPrefeb == null)
        {
            wordPrefeb = GameObject.Find("Word Prefebs");
        }
        var wordIns = Instantiate(wordPrefeb,wordFather.transform);
        var wordInfo = wordIns.GetComponent<WordInstanceInfo>();
        wordInfo.wordDataFather = getTargrtTest;
        wordInfo.WordDataUpdata();
        wordInfo.transform.position = wordCreateArea.transform.position;
    }
}
