using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New eventlist", menuName = "Event/New eventlist")]
public class ShijianList : ScriptableObject
{
    public List<Shijian> shijianlist = new List<Shijian>();
}