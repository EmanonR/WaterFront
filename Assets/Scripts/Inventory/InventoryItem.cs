using UnityEngine;

public enum FishSize { Tiny, Small, Medium, Large, Monster }

[System.Serializable]
public class InventoryItem
{
    public Item item;
    public FishSize size;

    static readonly float[] sizeMultipliers = { .5f, 1f, 1.5f, 2.5f, 5f };

    public InventoryItem(Item item, FishSize size)
    {
        this.item = item;
        this.size = size;
    }

    public int GetValue()
    {
        if (item is Fish fish)
            return Mathf.Max(1, Mathf.FloorToInt(fish.baseValue * sizeMultipliers[(int)size]));
        
        return 0;
    }
}
