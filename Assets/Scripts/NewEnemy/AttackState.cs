using UnityEngine;

public class AttackState : EnemyState
{
    private float _lastAttackTime;

    public AttackState(EnemyController controller) : base(controller) {}

    public override void EnterState() // Почему public?
    {
        _lastAttackTime = Time.time; // Что такое Time.time?
        PerformAttack();
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
            if (Time.time >= _lastAttackTime + _enemy.enemyData.attackCooldown)
            {
                PerformAttack();
                _lastAttackTime = Time.time;
            }
        }
    }

    public override void ExitState()
    {
        throw new System.NotImplementedException();
    }

    private void PerformAttack()
    {
        HealthSystem playerHealth = _enemy.player.GetComponent<HealthSystem>(); // Разобраться чем отличаются модификаторы доступа переменных
        if (playerHealth != null)
        {
            playerHealth.ChangeHealthPointsOn(_enemy.enemyData.damage);
        }
    }
}