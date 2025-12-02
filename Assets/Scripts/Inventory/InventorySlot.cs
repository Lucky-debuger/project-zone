using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;
    public TMP_Text textMeshPro;
    public ItemScriptableObject item;


    public void Initialize(ItemScriptableObject inventoryScriptableObject)
    {
        icon.sprite = inventoryScriptableObject.Icon;
        textMeshPro.text = inventoryScriptableObject.Name;
    }
    public void OnShowRemoveButton()
    // Кнопкой является сам слот
    {
        removeButton.gameObject.SetActive(!removeButton.gameObject.activeSelf);
    }

    public void OnRemoveButton()
    {
        Inventory.inventoryInstance.DeleteItem(item);
        Destroy(gameObject);
    }
}
