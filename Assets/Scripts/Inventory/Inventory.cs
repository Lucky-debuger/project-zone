using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<Item> startItems = new List<Item>();
    public List<Item> inventoryItems { get; private set; } // Когда стоит использовать свойства?;

    public Action<Item> onItemAdded;

    public void Initialize()
    {
        inventoryItems = new List<Item>();
        for (int i = 0; i < startItems.Count; i++)
        {
            AddItem(startItems[i]);
        }   
    }

    public void AddItem(Item item)
    {
        inventoryItems.Add(item);
        onItemAdded?.Invoke(item);
    }
}
