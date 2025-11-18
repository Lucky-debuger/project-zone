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
        RaycastHit2D raycastHit2D = Physics2D.Raycast(startPosition, endPosition);

        if (raycastHit2D.collider != null)
        {
            if (raycastHit2D.collider.TryGetComponent<IDamageable>(out IDamageable damageable))
            {
                damageable.GetDamage(1);
            }
        }
    }
}
