using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private HealthSystem healthSystem;


    public void GetDamage(float countDamage)
    {
        healthSystem.ChangeHealthPointsOn(countDamage);
    }
}
