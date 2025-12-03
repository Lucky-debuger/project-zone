using System.Collections.Generic;
using UnityEngine;

public class InventoryWindow : MonoBehaviour
{
    [SerializeField] private Inventory targetInventory;
    [SerializeField] private RectTransform itemsPanel;
    [SerializeField] private GameObject inventorySlotPrefab;

    private readonly List<GameObject> _drawnSlots = new List<GameObject>();

    public void Initialize()
    {
        targetInventory.OnItemAdded += OnItemAdded;
        Redraw();
    }

    private void OnItemAdded(ItemScriptableObject item) => Redraw();

    private void Redraw()
    {
        ClearDrawn();
        for (int i = 0; i < targetInventory.inventoryItems.Count; i++)
        {
            InventorySlot inventorySlot = Instantiate(inventorySlotPrefab).GetComponent<InventorySlot>();
            inventorySlot.Initialize(targetInventory.inventoryItems[i]);
            inventorySlot.transform.SetParent(itemsPanel);
            inventorySlot.transform.localScale = Vector3.one;
            _drawnSlots.Add(inventorySlot.gameObject);
        }
    }

    private void ClearDrawn()
    {
        for (int i = 0; i < _drawnSlots.Count; i++)
        {
            Destroy(_drawnSlots[i]);
        }
        _drawnSlots.Clear();
    }

    public void ToggleInventoryActivity() => gameObject.SetActive(!gameObject.activeSelf);
}
