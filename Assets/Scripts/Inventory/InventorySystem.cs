using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventorySystem" , menuName = "Invetory/InventorySystem")]
public class InventorySystem : ScriptableObject
{
    public List<InventorySlots> inventoryslots = new List<InventorySlots>();
    public void AddItem(Item _item , int _amount)
    {
        bool hasItem = false;
       
        for (int i = 0; i < inventoryslots.Count; i++)
        {
            if(inventoryslots[i].item == _item)
            {
                inventoryslots[i].AddAmount(_amount);
                hasItem = true;
                break;
            }
        }

        if(!hasItem)
        {
            inventoryslots.Add(new InventorySlots(_item, _amount));
        }
        
    }
}

[System.Serializable]
public class InventorySlots
{
    public Item item;
    public int amount;

    public InventorySlots(Item _item , int _amount)
    {
        item = _item;
        amount = _amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }
}
