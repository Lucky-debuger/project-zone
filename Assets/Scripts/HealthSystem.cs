using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float HealthPoints;

    public Action<float> OnHealthPointsChanged;

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
        Destroy(gameObject);
    }
}
