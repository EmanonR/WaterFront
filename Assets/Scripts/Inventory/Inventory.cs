using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> items = new();
    public int inventoryLimit = 8;

    public static Inventory Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public int GetInventoryEmptyCount()
    {
        return inventoryLimit - items.Count;
    }

    public void AddItem(InventoryItem item)
    {
        if (items.Count >= inventoryLimit) 
        {
            return;
        }
        items.Add(item);
    }

    public void RemoveItem(InventoryItem item)
    {
        items.Remove(item);
    }

    public bool TryRemoveItem(Item template)
    {
        foreach (InventoryItem item in items)
        {
            if (item.item == template)
            {
                RemoveItem(item);
                return true;
            }
        }

        return false;
    }

    public bool HasItem(Item template)
    {
        foreach (InventoryItem item in items)
        {
            if (item.item == template)
                return true;
        }

        return false;
    }
}
