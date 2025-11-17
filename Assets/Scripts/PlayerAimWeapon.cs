using UnityEngine;

public class PlayerAimWeapon : MonoBehaviour
{
    [SerializeField] BulletTracer bulletTracer;
    private Transform aimTransform;
    private Transform firePos;

    private void Awake()
    {
        aimTransform = transform.Find("Aim");
        firePos = transform.Find("Aim/FirePos");

        PlayerInput.OnMouseMoved += HandleAiming;
        PlayerInput.OnFirePerformed += HandleShooting;
    }

    private void HandleAiming(Vector2 mousePosition)
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 aimDirection = (worldPosition - aimTransform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg; // transform.LookAt(aimDirection);
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
    }

    private void HandleShooting(Vector2 mouseClickPosition)
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mouseClickPosition);
        worldPosition.z = 0;
        BulletTracer tracer = Instantiate(bulletTracer);
        tracer.CreateWeaponTracer(firePos.position, worldPosition);
        // Debug.DrawLine(firePos.transform.position, worldPosition, Color.white, .5f);
    }

}
