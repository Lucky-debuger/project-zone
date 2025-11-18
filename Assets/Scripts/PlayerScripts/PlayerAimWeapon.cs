using System;
using UnityEngine;


public class PlayerAimWeapon : MonoBehaviour
{
    [SerializeField] private Gun currentWeapon;
    private Transform aimTransform;
    private Transform firePos;
  
    private void Awake()
    {
        aimTransform = transform.Find("Aim");
        firePos = transform.Find("Aim/Pistol/FirePos");
        // currentWeapon = GetComponentInChildren<IWeapon>(); // Компонент?

        PlayerInput.OnMouseMoved += HandleAiming;
        PlayerInput.OnClickPerformed += HandleShooting;
    }

    private void HandleAiming(Vector2 mousePosition)
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 aimDirection = (worldPosition - aimTransform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg; // transform.LookAt(aimDirection);
        aimTransform.eulerAngles = new Vector3(0, 0, angle);

        Vector3 aimLocalScale = Vector3.one;

        if (angle > 90 || angle < -90)
        {
            aimLocalScale.y = -1f;
        }
        else
        {
            aimLocalScale.y = +1f;
        }
        aimTransform.localScale = aimLocalScale;
    }

    private void HandleShooting(Vector2 mouseClickPosition)
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mouseClickPosition);
        worldPosition.z = 0;

        currentWeapon?.Fire(firePos.position, worldPosition);
        // animator.Play("FireAnimation", 0, 0f); // Можно вынести в отделный класс и использовать
        // BulletTracer tracer = Instantiate(bulletTracer); // Можно вынести в отделный класс и использовать
        // tracer.CreateBulletTracer(firePos.position, worldPosition);
        // OnShootPerformed?.Invoke(firePos.position, worldPosition);
        // // Debug.DrawLine(firePos.transform.position, worldPosition, Color.white, .5f);
    }
}
