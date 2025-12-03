using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Button removeButton;
    [SerializeField] private TMP_Text textMeshPro;
    [SerializeField] private ItemScriptableObject item;


    public void Initialize(ItemScriptableObject inventoryScriptableObject)
    {
        icon.sprite = inventoryScriptableObject.Icon;
        textMeshPro.text = inventoryScriptableObject.Name;
        item = inventoryScriptableObject;
    }
    public void OnShowRemoveButton()
    // Кнопкой является сам слот
    {
        removeButton.gameObject.SetActive(!removeButton.gameObject.activeSelf);
    }

    public void OnRemoveButton()
    {
        Inventory.Instance.DeleteItem(item);
        Destroy(gameObject);
    }
}
