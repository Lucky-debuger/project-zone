using UnityEngine;
using UnityEngine.InputSystem;

public class ItemTaker : MonoBehaviour
{
    [SerializeField] ItemScriptableObject itemToAdd;
    [SerializeField] Inventory targetInventory;


    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            targetInventory.AddItem(itemToAdd);
        }
    }
}
