using UnityEngine;


public class PlayerAimWeapon : MonoBehaviour
{
    [SerializeField] BulletTracer bulletTracer;
    [SerializeField] Animator animator;
    private Transform aimLocalScale;
    private Transform aimTransform;
    private Transform firePos;
  

    private void Awake()
    {
        aimTransform = transform.Find("Aim");
        firePos = transform.Find("Aim/Pistol/FirePos");

        PlayerInput.OnMouseMoved += HandleAiming;
        PlayerInput.OnFirePerformed += HandleShooting;
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
        animator.Play("FireAnimation", 0, 0f); // Можно вынести в отделный класс и использовать Observer
        BulletTracer tracer = Instantiate(bulletTracer); // Можно вынести в отделный класс и использовать Observer
        tracer.CreateWeaponTracer(firePos.position, worldPosition);
        // Debug.DrawLine(firePos.transform.position, worldPosition, Color.white, .5f);
    }
}
