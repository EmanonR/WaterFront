using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryObject;
    public GameObject inventorySlotPrefab;
    public bool on;
    public Transform gridParent;
    public List<GameObject> inventorySlots;
    int inventorySlotCount = 8;

    private void Update()
    {
        if (InputManager.Instance.inventoryKey.WasPressedThisFrame())
        {
            on = !on;

            inventoryObject.SetActive(on);

            foreach (var slot in inventorySlots)
            {
                Destroy(slot);
            }

            inventorySlots.Clear();

            for (int i = 0; i < inventorySlotCount; i++)
            {
                InventoryItem item = null;
                if (i < Inventory.Instance.items.Count)
                    item = Inventory.Instance.items[i];

                GameObject slot = Instantiate(inventorySlotPrefab, gridParent);
                slot.GetComponent<InventorySlot>().SetItem(item);
                inventorySlots.Add(slot);
            }
        }
    }
}
