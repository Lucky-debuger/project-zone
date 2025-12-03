using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("Initialization")]
    [SerializeField] private List<ItemScriptableObject > startItems = new List<ItemScriptableObject >();
    [SerializeField] private bool _debugLogs = false;
    
    private bool _isInitialized = false;
    

    public static Inventory Instance { get; private set; }

    public List<ItemScriptableObject> inventoryItems { get; private set; }

    public Action<ItemScriptableObject > OnItemAdded;

    public void Initialize()
    {
        InitializeSingleton();
        InitializeInventory();
    }

    private void InitializeSingleton()
    {
        if (Instance != null && Instance != this)
        {
            if (_debugLogs) Debug.LogWarning($"Multiple Inventory instances detected. Destroying {gameObject.name}");
            Destroy(gameObject);
            return;
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