using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
//��Ʒ�Ĺ�������������ȡ��Ʒ
public class PropsController : MonoBehaviour
{
    private void Start()
    {
        Rigidbody2D Rigidbody2d = GetComponent<Rigidbody2D>();
        GetItem.Num = 0;
        Package.Items.Clear();
    }
    public GetItem GetItem;
    public Package Package;
}
