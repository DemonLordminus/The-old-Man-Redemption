using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum wordT //��wordType
{ 
    front,//��ν������ Ӣ��̫�� ����д��
    mid,
    back,
}

public enum wordM //wordMeaning ���ֵľ��庬�� Ŀǰ�õ���ö�� ��ʵ�ַ���Ҳ��
{ 
    danger,//Σ��
    safe,
    monster,
    hero,//���� ���� ������player
    _is,

}

//public class WordInfo //������
//{
//    private wordType wt;
//    private wordMeaning wm;
//    private string wordDisplay;

//    WordInfo(wordMeaning _wm) //���캯��
//    {
//        wm = _wm;
//        switch (wm)
//        { 
            
        
//        }
//    }
//}