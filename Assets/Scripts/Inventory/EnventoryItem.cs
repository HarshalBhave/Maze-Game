using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Equipement" , menuName = "Inventory/Equipement")]

public class EnventoryItem : Item
{
    public int attactAmount;
    public int sowardDamage;

    private void Awake()
    {
        type = ItemType.Equipement;
    }
}
