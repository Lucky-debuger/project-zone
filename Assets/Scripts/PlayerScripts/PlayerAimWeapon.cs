using System;
using UnityEngine;


public class PlayerAimWeapon : MonoBehaviour
{
    [SerializeField] private Gun currentWeapon;

    private Transform _aimTransform;
    private Transform _firePos;
   
    private void Awake()
    {
        _aimTransform = transform.Find("Aim");
        _firePos = transform.Find("Aim/Pistol/_firePos");

        PlayerInput.OnMouseMoved += HandleAiming;
        PlayerInput.OnClickAtPositionPerformed += HandleShooting;
    }

    private void HandleAiming(Vector2 mousePosition)
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 aimDirection = (worldPosition - _aimTransform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg; // transform.LookAt(aimDirection);
        _aimTransform.eulerAngles = new Vector3(0, 0, angle);

        Vector3 aimLocalScale = Vector3.one;

        if (angle > 90 || angle < -90)
        {
            aimLocalScale.y = -1f;
        }
        else
        {
            aimLocalScale.y = +1f;
        }
        _aimTransform.localScale = aimLocalScale;
    }

    private void HandleShooting(Vector2 mouseClickPosition)
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mouseClickPosition);
        worldPosition.z = 0;
        currentWeapon?.Fire(_firePos.position, worldPosition);
    }
}
