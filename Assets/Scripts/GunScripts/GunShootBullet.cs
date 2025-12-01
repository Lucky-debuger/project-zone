using System.Collections;
using UnityEngine;

public class GunShootBullet : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform firePosition;
    [SerializeField] private float spreadSpeed;
    public float spreadAngle {get; private set;}
    

    private void Start()
    {
        PlayerMovement.OnContinuousMovement += increaseSpreadAngle;
        StartCoroutine(decreaseSpreadAngle());
    }

    public void Fire()
    {
        increaseSpreadAngle();
        Bullet bullet = Instantiate(bulletPrefab, firePosition.position, firePosition.transform.rotation);
        bullet.SetInitialDirection(spreadAngle);
    }

    private void increaseSpreadAngle()
    {
        if (spreadAngle >= 40) return;
        spreadAngle += 3;
    }

    private IEnumerator decreaseSpreadAngle()
    {
        while (true)
        {
            spreadAngle -= spreadSpeed;
            if (spreadAngle <= 0) spreadAngle = 0;
            yield return new WaitForSeconds(0.3f);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(firePosition.position, firePosition.right);

        Quaternion rotation = Quaternion.Euler(0, 0, +spreadAngle/2);
        Vector3 rotatedDirection = rotation * firePosition.right;
        Gizmos.DrawRay(firePosition.position, rotatedDirection);

        rotation = Quaternion.Euler(0, 0, -spreadAngle/2);
        rotatedDirection = rotation * firePosition.right;
        Gizmos.DrawRay(firePosition.position, rotatedDirection);
    }

}
