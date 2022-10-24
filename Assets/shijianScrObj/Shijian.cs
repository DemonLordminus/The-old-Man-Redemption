using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New event",menuName = "Event/New event")]
public class Shijian : ScriptableObject
{
    //public GameObject player;
    public string eventname;
    [TextArea]
    public string eventinfomation;
    //public string eventeffect;
    public float hpchange = 0;
    public float spchange = 0;
    public float bpchange = 0 ;
    public float goldchange = 0;
    //public bool isNormal;
}
