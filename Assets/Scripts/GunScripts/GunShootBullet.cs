using System;
using UnityEngine;

public class GunShootBullet : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform firePosition;
    
    public event Action<Vector3, Vector3> OnWeaponFired;

    public void Fire()
    {
        Bullet bullet = Instantiate(bulletPrefab, firePosition.position, firePosition.transform.rotation);
    }
}
