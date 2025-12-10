using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private HealthSystem healthSystem;

    private void Start()
    {
        healthSystem.SetHealthPoints(100);
    }

    public void GetDamage(float countDamage)
    {
        healthSystem.ChangeHealthPointsOn(countDamage);
    }
}
