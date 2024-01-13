using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "FoodObject" , menuName = "Inventory/FoodItem")]
public class FoodItem : Item
{
    public int restoreHealth;
    private void Awake()
    {
        type = ItemType.food;
    }

}
