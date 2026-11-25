using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    private void Update()
    {
        if (InputManager.Instance.inventoryKey.WasPressedThisFrame())
        {
            print("Inventory:");
            foreach (var item in Inventory.Instance.items)
                print($"{item.size} {item.item.DisplayName}");
        }
    }
}
