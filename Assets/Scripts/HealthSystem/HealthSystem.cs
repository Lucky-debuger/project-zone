using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float HealthPoints {get; private set;}

    public Action<float> OnHealthPointsChanged;
    public Action OnDied;

    private float _maxHealth = 100;

    public void SetHealthPoints(float points)
    {
        HealthPoints = Mathf.Clamp(points, 0, _maxHealth);
    }

    public void ChangeHealthPointsOn(float countHealthPoints)
    {
        HealthPoints -= countHealthPoints;
        HealthPoints = Mathf.Clamp(HealthPoints, 0.0f, 100.0f);
        OnHealthPointsChanged?.Invoke(HealthPoints);

        if (HealthPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        OnDied?.Invoke();
        Destroy(gameObject);
    }
}
