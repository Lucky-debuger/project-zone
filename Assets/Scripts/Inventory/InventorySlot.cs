using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Button removeButton;
    [SerializeField] private TMP_Text nameTMP;
    [SerializeField] private TMP_Text countTMP;
    [SerializeField] private ItemScriptableObject item;

    public void Initialize(ItemScriptableObject inventoryScriptableObject, int count)
    {
        icon.sprite = inventoryScriptableObject.Icon;
        nameTMP.text = inventoryScriptableObject.Name;

        item = inventoryScriptableObject;
        countTMP.text = Inventory.Instance.itemDicttionary[item].ToString();
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