using System;
using UnityEngine;

public class Gun : MonoBehaviour, IWeapon
{
    [SerializeField] private BulletTracer bulletTracer;
    [SerializeField] private Animator animator;

    public event Action<Vector3, Vector3> OnWeaponFired;

    public void Fire(Vector3 firePosition, Vector3 targetPosition)
    {
        animator.Play("FireAnimation", 0, 0f);
        BulletTracer tracer = Instantiate(bulletTracer);
        tracer.CreateBulletTracer(firePosition, targetPosition);
        OnWeaponFired?.Invoke(firePosition, targetPosition);
        // Debug.DrawLine(firePos.transform.position, worldPosition, Color.white, .5f);
    }
}
