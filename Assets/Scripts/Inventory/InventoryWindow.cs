using System.Collections.Generic;
using UnityEngine;

public class InventoryWindow : MonoBehaviour
{
    [SerializeField] private Inventory targetInventory;
    [SerializeField] private RectTransform itemsPanel;
    [SerializeField] private GameObject inventorySlotPrefab;


    readonly List<GameObject> drawnSlots = new List<GameObject>(); // Почему readonly?

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
            InventorySlot inventorySlot = Instantiate(inventorySlotPrefab).GetComponent<InventorySlot>();
            inventorySlot.Initialize(targetInventory.inventoryItems[i]);
            inventorySlot.transform.SetParent(itemsPanel); // Зачем transform?
            inventorySlot.transform.localScale = Vector3.one;
            drawnSlots.Add(inventorySlot.gameObject);
        }
    }

    private void ClearDrawn()
    {
        for (int i = 0; i < drawnSlots.Count; i++)
        {
            Destroy(drawnSlots[i]);
        }
    }

    public void ToggleInventoryActivity() => gameObject.SetActive(!gameObject.activeSelf);
}
