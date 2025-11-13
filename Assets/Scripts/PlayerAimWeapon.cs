using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerAimWeapon : MonoBehaviour
{
    private Transform aimTransform;

    private void Awake()
    {
        aimTransform = transform.Find("Aim");
    }

    private void Update()
    {
        // Vector2 mousePosition = Mouse.current.position.ReadValue();
        // Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        // worldPosition.z = 0;
        // Debug.Log($"Screen: {mousePosition} World: {worldPosition}");

        Vector3 Mouse.current.position.ReadValue();
    }

}
