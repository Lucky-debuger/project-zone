using UnityEngine;

public class EnemyController : MonoBehaviour, IDamageable
{
    [Header("Enemy data")]
    public EnemyData enemyData;
    
    [Header("Links")]
    public Transform player;
    [SerializeField] private HealthSystem healthSystem;
    
    private EnemyState currentState;
    // private float currentHealth;
    
    
    void Start()
    {
        // currentHealth = enemyData.health;
        healthSystem.SetHealthPoints(100);
        
        player = GameObject.FindGameObjectWithTag("Player").transform; // Подумать о вариантах получения объекта
        
        SetState(new IdleState(this));
    }

    private void Update()
    {
        currentState?.UpdateState();
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

    public void GetDamage(float damage)
    {
        healthSystem.ChangeHealthPointsOn(damage);
    }
    
    private void Die()
    {
        Destroy(gameObject);
    }
}