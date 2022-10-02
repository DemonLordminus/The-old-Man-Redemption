using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new package",menuName = "Inventory/New Package")]
public class Package : ScriptableObject
{
    public List<GetItem> Items= new List<GetItem> { };
}
