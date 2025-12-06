using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy data")]
    public EnemyData enemyData;
    
    [Header("Links")]
    public Transform player;
    
    private EnemyState currentState;
    private float currentHealth;
    
    void Start()
    {
        currentHealth = enemyData.health;
        player = GameObject.FindGameObjectWithTag("Player").transform; // Подумать о вариантах получения объекта
        
        SetState(new IdleState(this));
    }
    
    public void SetState(EnemyState newState)
    {
        currentState?.ExitState();
        currentState = newState;
        currentState?.EnterState();   
    }

    public bool CanSeePlayer()
    {
        return Vector2.Distance(transform.position, player.position) <= enemyData.detectionRange;
    }
    
    public void MoveTowardsPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        transform.Translate(direction * enemyData.moveSpeed * Time.deltaTime);
    }

    public bool CanAttackPlayer() // Переписал на свой вариант
    {
        return Vector2.Distance(transform.position, player.position) <= enemyData.attackRange;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
            Die();
    }
    
    private void Die()
    {
        Destroy(gameObject);
    }
}