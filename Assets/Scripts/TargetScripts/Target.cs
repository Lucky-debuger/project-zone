using System;
using UnityEngine;

public class Target : MonoBehaviour, IDamageable
{
    public event Action OnGetDamaged;
    public void GetDamage(int damageAmount)
    {
        OnGetDamaged?.Invoke();
    }
}
