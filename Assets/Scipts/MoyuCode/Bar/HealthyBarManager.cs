using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//血条管理器
public class HealthyBarManager : MonoBehaviour
{
    //单例化血条,获取当前血条本身
    public static HealthyBarManager Instance { get; private set; }
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
        mask .rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize*value);
    }
}
