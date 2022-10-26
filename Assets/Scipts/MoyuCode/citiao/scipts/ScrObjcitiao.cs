using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Citiao", menuName = "Inventory/New Citiao")]
public class ScrObjcitiao : ScriptableObject
{
    public string Name;
    public Sprite[] Image;
    [Header("中文内容")]
    public string Content;
    [Header("类型")]
    public wordType type;
    [Header("反义词")]
    public ScrObjcitiao reverseWord;
    [Header("编号 在WordDataManager可以统一赋予编号，这里不用改")]
    public int serialNum;
    public float hpChange, spChange, bpChange, moneyChange;
}

public enum wordType
{
    [InspectorName("场景交互元素")]
    eventElement = 0,//场景交互元素
    [InspectorName("生活风格")]
    lifeStyle = 1,//生活风格
    [InspectorName("是 谓词")]
    _is = 2,//谓词 是 这个不一定用得到
    [InspectorName("动词")]
    verb = 3,//动词
    [InspectorName("好坏 形容词")]
    goodOrBad = 4//好与坏
}