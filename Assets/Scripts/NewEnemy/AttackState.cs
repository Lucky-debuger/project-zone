using UnityEngine;

public class AttackState : EnemyState
{
    private float _attackTimer;

    public AttackState(EnemyController controller) : base(controller) {}

    public override void EnterState()
    {
        
    }

    public override void UpdateState()
    {
        if (!_enemy.CanAttackPlayer())
        {
            if (_enemy.CanSeePlayer())
            {
                _enemy.SetState(new ChasingState(_enemy));
            }
            else
            {
                _enemy.SetState(new IdleState(_enemy));
            }
        }
        else
        {
            if (_attackTimer >= _enemy.enemyData.attackCooldown)
            {
                PerformAttack();
                _attackTimer = 0.0f;
            }
            _attackTimer += Time.deltaTime;

        }
    }

    public override void ExitState()
    {

    }

    private void PerformAttack()
    {
        // HealthSystem playerHealth = _enemy.player.GetComponent<HealthSystem>();
        // if (playerHealth != null)
        // {
        //     playerHealth.ChangeHealthPointsOn(_enemy.enemyData.damage);
        // }
        _enemy.player.GetComponent<Player>().GetDamage(_enemy.enemyData.damage);
        Debug.Log("Аттакую!");
    }
}