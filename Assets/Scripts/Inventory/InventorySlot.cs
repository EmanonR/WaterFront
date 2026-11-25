using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] Image spriteImage;

    InventoryItem myItem;

    private void OnEnable() => UpdateUI();

    public void RemoveItem()
    {
        myItem = null;
        UpdateUI();
    }

    public void SetItem(InventoryItem newItem)
    {
        myItem = newItem;
        UpdateUI();
    }

    public void UpdateUI()
    {
        if ( myItem == null)
        {
            spriteImage.gameObject.SetActive(false);
            return;
        }

        spriteImage.gameObject.SetActive(true);
        spriteImage.sprite = myItem.item.sprite;
    }
}
