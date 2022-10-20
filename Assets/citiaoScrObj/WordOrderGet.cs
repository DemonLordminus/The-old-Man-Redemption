using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordOrderGet : MonoBehaviour
{
    [SerializeField]
    public WordDataManagerScr wordWordDataManager;

    [EditorButton]
    void orderGet()
    {
        wordWordDataManager.wordSerialNumGive();
    }
} 
