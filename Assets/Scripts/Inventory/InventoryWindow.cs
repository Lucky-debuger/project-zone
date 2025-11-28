using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWindow : MonoBehaviour
{
    [SerializeField] private Inventory targetInvetory;
    [SerializeField] private RectTransform itemsPanel;

    readonly List<GameObject> drawnIcons = new List<GameObject>(); // Почему readonly?

    public void Initialize()
    {
        targetInvetory.onItemAdded += OnItemAdded;
        Redraw();
    }

    private void OnItemAdded(Item item) => Redraw(); // Почему сразу не вызвать Redraw? 
    // {
    //     throw new System.NotImplementedException(); Что это такое?
    // }

    private void Redraw()
    {
        ClearDrawn();
        for (int i = 0; i < targetInvetory.inventoryItems.Count; i++)
        {
            Item item = targetInvetory.inventoryItems[i];
            GameObject icon = new GameObject("icon");
            Image iconImage = icon.AddComponent<Image>();
            iconImage.sprite = item.Icon;
            iconImage.preserveAspect = true;
            icon.transform.SetParent(itemsPanel);
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
