using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Inventory/Item")]
public class ItemScriptableObject : ScriptableObject
{
    [Header("Basic Info")]
    public string Name = "Item";
    public Sprite Icon;
}
