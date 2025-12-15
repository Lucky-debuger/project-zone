using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Dictionary<ItemScriptableObject, int> itemDicttionary { get; private set; } = new Dictionary<ItemScriptableObject, int>();
    public static Inventory Instance { get; private set; }
    public Action<ItemScriptableObject> OnItemAdded;

    public void Initialize()
    {
        InitializeSingleton();
    }

    private void InitializeSingleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void AddItem(ItemScriptableObject itemScriptableObject)
    {
        if (itemDicttionary.ContainsKey(itemScriptableObject))
        {
            itemDicttionary[itemScriptableObject]++;
        }
        else
        {
            itemDicttionary[itemScriptableObject] = 1;
        }

        OnItemAdded?.Invoke(itemScriptableObject);
    }

    public void DeleteItem(ItemScriptableObject itemScriptableObject)
    {
        if (!itemDicttionary.ContainsKey(itemScriptableObject)) return;

        if (itemDicttionary[itemScriptableObject] > 1)
        {
            itemDicttionary[itemScriptableObject]--;
        }
        else
        {
            itemDicttionary.Remove(itemScriptableObject);
        }
    }
}
