using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<ItemScriptableObject > startItems = new List<ItemScriptableObject >();
    public List<ItemScriptableObject > inventoryItems { get; private set; } // Когда стоит использовать свойства?;

    public Action<ItemScriptableObject > onItemAdded;

    public void Initialize()
    {
        inventoryItems = new List<ItemScriptableObject >();
        for (int i = 0; i < startItems.Count; i++)
        {
            AddItem(startItems[i]);
        }   
    }

    public void AddItem(ItemScriptableObject ItemScriptableObject)
    {
        inventoryItems.Add(ItemScriptableObject);
        onItemAdded?.Invoke(ItemScriptableObject);
    }
}
