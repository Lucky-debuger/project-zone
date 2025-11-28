using UnityEngine;

public class ItemGameObject : MonoBehaviour, IPickable
{
    public ItemScriptableObject itemScriptableObject;

    public void AddToInventory(Inventory inventory)
    {
        inventory.AddItem(itemScriptableObject);
        Destroy(gameObject);
    }
}
