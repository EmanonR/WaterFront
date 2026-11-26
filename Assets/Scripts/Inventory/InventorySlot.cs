using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] Image spriteImage;
    [SerializeField] Button deleteButton;

    InventoryItem myItem;

    private void Awake()
    {
        deleteButton.onClick.AddListener(RemoveItem);
    }

    private void OnEnable() => UpdateUI();

    public void RemoveItem()
    {
        Inventory.Instance.RemoveItem(myItem);
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
            deleteButton.gameObject.SetActive(false);
            return;
        }

        deleteButton.gameObject.SetActive(true);
        spriteImage.gameObject.SetActive(true);
        spriteImage.sprite = myItem.item.sprite;
    }
}
