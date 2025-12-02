using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<ItemScriptableObject > startItems = new List<ItemScriptableObject >();
    public static Inventory inventoryInstance;
    public List<ItemScriptableObject > inventoryItems { get; private set; } // Когда стоит использовать свойства?;

    public Action<ItemScriptableObject > onItemAdded;

    public void Initialize()
    {
        if (inventoryInstance != null && inventoryInstance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            // DontDestroyOnLoad(gameObject); Что это и зачем?
            inventoryInstance = this;
        }

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

    public void DeleteItem(ItemScriptableObject itemScriptableObject)
    {
        inventoryItems.Remove(itemScriptableObject);
    }
}
