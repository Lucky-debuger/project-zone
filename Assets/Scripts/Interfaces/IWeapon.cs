using System;
using UnityEngine;
public interface IWeapon
{
    public void Fire(Vector3 firePosition, Vector3 targetPosition);
    public event Action<Vector3, Vector3> OnWeaponFired;
}