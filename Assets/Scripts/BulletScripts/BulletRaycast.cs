using System.IO.Compression;
using UnityEngine;

public class BulletRaycast : MonoBehaviour
{
    [SerializeField] Gun gun;
    private void Awake()
    {
        gun.OnWeaponFired += Shoot;
    }
    private void Shoot(Vector3 startPosition, Vector3 endPosition)
    {
        Vector2 direction = (endPosition - startPosition).normalized;
        float distance = Vector2.Distance(startPosition, endPosition);
        RaycastHit2D raycastHit2D = Physics2D.Raycast(startPosition, direction, distance);
        Debug.DrawRay(startPosition, direction * distance, Color.red, 0.3f);
        Debug.Log($"Raycasthit2d: {startPosition}, {endPosition};");

        if (raycastHit2D.collider != null)
        {
            // if (raycastHit2D.collider.TryGetComponent<IDamageable>(out IDamageable damageable))
            if (raycastHit2D.collider.TryGetComponent<IDamageable>(out IDamageable damageable))
            {
                damageable.GetDamage(25f);
            }
        }
    }
}
