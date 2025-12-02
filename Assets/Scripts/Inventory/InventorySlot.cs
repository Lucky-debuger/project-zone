using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;
    public TMP_Text textMeshPro;
    public ItemScriptableObject item;

    public void OnShowRemoveButton()
    // Кнопкой является сам слот
    {
        removeButton.gameObject.SetActive(!removeButton.gameObject.activeSelf);
    }

    public void OnRemoveButton()
    {
        Destroy(gameObject);
    }
}
