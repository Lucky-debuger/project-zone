using UnityEngine;

public class ItemGameObject : MonoBehaviour, IPickable
{
    [SerializeField] private ItemScriptableObject itemScriptableObject;

    public void AddToInventory(Inventory inventory)
    {
        inventory.AddItem(itemScriptableObject);
        Destroy(gameObject);
    }
}
