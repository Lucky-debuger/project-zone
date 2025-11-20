using UnityEngine;

public class EnemyController : MonoBehaviour, IDamageable
{
    [SerializeField] private EnemyType1Data enemyType1Data;
    private EnemyAI enemyAI;

    private void Start()
    {
        enemyAI = GetComponent<EnemyAI>();
    }

    public void GetDamage(float damageAmount)
    {
        enemyType1Data.HP -= damageAmount;
        if (enemyType1Data.HP <= 0.0f)
        {
            Destroy(gameObject, 0.1f);
        }
    }
}
