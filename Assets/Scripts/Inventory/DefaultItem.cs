using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultItem" , menuName = "Inventory/DefaultItem")]
public class DefaultItem : Item
{
    private void Awake()
    {
        type = ItemType.Default;
    }
}
