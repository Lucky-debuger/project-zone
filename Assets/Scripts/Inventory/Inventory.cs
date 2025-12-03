using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<ItemScriptableObject > startItems = new List<ItemScriptableObject >();
    
    public static Inventory Instance { get; private set; }
    public List<ItemScriptableObject> inventoryItems { get; private set; }
    public Action<ItemScriptableObject > OnItemAdded;
    private bool _isInitialized = false;

    public void Initialize()
    {
        InitializeSingleton();
        InitializeInventory();
    }

    private void InitializeSingleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void InitializeInventory()
    {
        if (_isInitialized) return;

        inventoryItems = new List<ItemScriptableObject>();
        for (int i = 0; i < startItems.Count; i++)
        {
            AddItem(startItems[i]);
        }

        _isInitialized = true;
    }

    public void AddItem(ItemScriptableObject ItemScriptableObject)
    {
        inventoryItems.Add(ItemScriptableObject);
        OnItemAdded?.Invoke(ItemScriptableObject);
    }

    public void DeleteItem(ItemScriptableObject itemScriptableObject)
    {
        inventoryItems.Remove(itemScriptableObject);
    }
}