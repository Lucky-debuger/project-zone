using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<Item> StartItems = new List<Item>();
    public List<Item> inventoryItems = new List<Item>();

    public void Initialize()
    {
        for (int i = 0; i < StartItems.Count; i++)
        {
            AddItem(StartItems[i]);
        }
        Debug.Log(inventoryItems.Count);
    }

    private void AddItem(Item item)
    {
        inventoryItems.Add(item);
    }
}
