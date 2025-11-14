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
        HandleAiming();
        // HandleShooting();
    }

    private void HandleAiming()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 aimDirection = (worldPosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg; // transform.LookAt(aimDirection);
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
    }
    // private void HandleShooting()
    // {
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         Debug.Log("Bang!");
    //     }
    // }

}
