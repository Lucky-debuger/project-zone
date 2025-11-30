using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private InventoryWindow inventoryWindow;
    [SerializeField] private ItemDroper itemDroper;

    private void Awake()
    {
        inventory.Initialize();
        inventoryWindow.Initialize();
    } 
}


