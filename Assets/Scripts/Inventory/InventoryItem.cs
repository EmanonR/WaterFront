using UnityEngine;

public enum FishSize { Tiny, Small, Medium, Large, Monster }

[System.Serializable]
public class InventoryItem
{
    public Item item;
    public FishSize size;

    public InventoryItem(Item item, FishSize size)
    {
        this.item = item;
        this.size = size;
    }
}
