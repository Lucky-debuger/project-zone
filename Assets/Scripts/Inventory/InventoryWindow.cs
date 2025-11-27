using UnityEngine;
using UnityEngine.UI;

public class InventoryWindow : MonoBehaviour
{
    [SerializeField] private Inventory targetInvetory;
    [SerializeField] private RectTransform itemsPanel;
    [SerializeField] private bool Visibility;

    public void Initialize()
    {
        Redraw();
    }

    private void Redraw()
    {
        Debug.Log(targetInvetory.inventoryItems.Count);
        for (int i = 0; i < targetInvetory.inventoryItems.Count; i++)
        {
            Item item = targetInvetory.inventoryItems[i];
            GameObject icon = new GameObject("icon");
            icon.AddComponent<Image>().sprite = item.Icon;
            icon.transform.SetParent(itemsPanel);
            icon.GetComponent<Image>().preserveAspect = true;
            Debug.Log("1");
        }
    }
}
