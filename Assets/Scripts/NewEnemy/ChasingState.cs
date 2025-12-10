using UnityEngine;
public class ChasingState : EnemyState
{
    public ChasingState(EnemyController controller) : base(controller){}
    public override void EnterState()
    {
        
    }

    public override void UpdateState()
    {
        if (!_enemy.CanSeePlayer())
        {
            _enemy.SetState(new IdleState(_enemy));
            return;
        }

        // if (_enemy.CanSeePlayer())
        // {
        //     _enemy.SetState(new AttackState(_enemy));
        // }

        _enemy.MoveTowardsPlayer();
    }

    public override void ExitState()
    {
        
    }
}
