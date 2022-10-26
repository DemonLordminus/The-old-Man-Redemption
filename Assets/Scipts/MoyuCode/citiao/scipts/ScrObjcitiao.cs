using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Citiao", menuName = "Inventory/New Citiao")]
public class ScrObjcitiao : ScriptableObject
{
    public string Name;
    public Sprite[] Image;
    [Header("��������")]
    public string Content;
    [Header("����")]
    public wordType type;
    [Header("�����")]
    public ScrObjcitiao reverseWord;
    [Header("��� ��WordDataManager����ͳһ�����ţ����ﲻ�ø�")]
    public int serialNum;
    public float hpChange, spChange, bpChange, moneyChange;
}

public enum wordType
{
    [InspectorName("��������Ԫ��")]
    eventElement = 0,//��������Ԫ��
    [InspectorName("������")]
    lifeStyle = 1,//������
    [InspectorName("�� ν��")]
    _is = 2,//ν�� �� �����һ���õõ�
    [InspectorName("����")]
    verb = 3,//����
    [InspectorName("�û� ���ݴ�")]
    goodOrBad = 4//���뻵
}