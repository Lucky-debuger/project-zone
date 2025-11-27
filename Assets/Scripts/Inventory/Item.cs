using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string Name = "Item";
    public Sprite Icon;
    public int price = 500;
}
