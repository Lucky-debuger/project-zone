using UnityEngine;
using UnityEngine.InputSystem;

public class ItemTaker : MonoBehaviour
{

    [SerializeField] Item itemToAdd;
    [SerializeField] Inventory targetInventory;


    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            targetInventory.AddItem(itemToAdd);
        }
    }
}
