using UnityEngine.UI;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;

    private ItemGameObject item;

    public void AddItem(ItemGameObject newItem)
    {
        item = newItem;
        icon.enabled = true;
        removeButton.interactable = true;
    }
}
