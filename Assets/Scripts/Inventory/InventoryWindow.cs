using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWindow : MonoBehaviour
{
    [SerializeField] private Inventory targetInventory;
    [SerializeField] private RectTransform itemsPanel;

    readonly List<GameObject> drawnIcons = new List<GameObject>(); // Почему readonly?

    public void Initialize()
    {
        targetInventory.onItemAdded += OnItemAdded;
        Redraw();
    }

    private void OnItemAdded(ItemScriptableObject item) => Redraw(); // Почему сразу не вызвать Redraw? 
    // {
    //     throw new System.NotImplementedException(); Что это такое?
    // }

    private void Redraw()
    {
        ClearDrawn();
        for (int i = 0; i < targetInventory.inventoryItems.Count; i++)
        {
            ItemScriptableObject item = targetInventory.inventoryItems[i];
            GameObject icon = new GameObject("icon");
            Image iconImage = icon.AddComponent<Image>();
            iconImage.sprite = item.Icon;
            iconImage.preserveAspect = true;
            icon.transform.SetParent(itemsPanel);
            icon.transform.localScale = Vector3.one;
            drawnIcons.Add(icon);
        }
    }

    private void ClearDrawn()
    {
        for (int i = 0; i < drawnIcons.Count; i++)
        {
            Destroy(drawnIcons[i]);
        }
    }
}
