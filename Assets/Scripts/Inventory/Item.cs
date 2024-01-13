using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    food ,
    Equipement ,
    Default,
}

public abstract class Item : ScriptableObject
{
    public GameObject objectPrefab;
    public ItemType type;
    [TextArea(15 ,  20)]
    public string description;
}
