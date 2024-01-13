using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InventroyDisplay : MonoBehaviour
{
    public InventorySystem inventorySystem;
    public int x_space_between;
    public int x_start;
    public int numberOfColumns;
    public int y_space_between;
    public int y_start;

    Dictionary<InventorySlots, GameObject> itemDisplay = new Dictionary<InventorySlots, GameObject>();

    private void Start()
    {
        CreateInventory();
    }

    private void Update()
    {
        UpdateInventory();
    }

    public void UpdateInventory()
    {
        for(int i = 0; i < inventorySystem.inventoryslots.Count; i++)
        {
            if(itemDisplay.ContainsKey(inventorySystem.inventoryslots[i]))
            {
                itemDisplay[inventorySystem.inventoryslots[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventorySystem.inventoryslots[i].amount.ToString("n0");
            } else
            {
                var obj = Instantiate(inventorySystem.inventoryslots[i].item.objectPrefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventorySystem.inventoryslots[i].amount.ToString("n0");
                itemDisplay.Add(inventorySystem.inventoryslots[i], obj);
            }
        }
    }




    public void CreateInventory()
    {
        for(int i = 0; i < inventorySystem.inventoryslots.Count; i++ )
        {
            var obj = Instantiate(inventorySystem.inventoryslots[i].item.objectPrefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventorySystem.inventoryslots[i].amount.ToString("n0");
            itemDisplay.Add(inventorySystem.inventoryslots[i], obj);
        }
    }

    public Vector3 GetPosition(int i)
    {
        return new Vector3(x_start + (x_space_between * (i % numberOfColumns)), y_start + (-y_space_between * (i / numberOfColumns)) , 0f);
    }
}
