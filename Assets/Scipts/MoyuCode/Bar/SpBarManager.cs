using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//体力条管理器
public class SpBarManager : MonoBehaviour
{
    //创建公有静态,获取当前体力条本身
    public static SpBarManager Instance { get; private set; }
    public Image mask;
    float originalSize;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        originalSize = mask.rectTransform.rect.width;
    }

    public void SetValue(float value)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }
}
