using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthyBarManager : MonoBehaviour
{
    //创建公有静态,获取当前血条本身
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
