using UnityEngine;

public class ItemPicker : MonoBehaviour
{
    [SerializeField] private Inventory inventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IPickable>(out IPickable pickable))
        {
            pickable.AddToInventory(inventory);
        }
    }
}
