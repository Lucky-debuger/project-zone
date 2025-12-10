using System;
using UnityEngine;

public class IdleState : EnemyState
{
    public IdleState(EnemyController controller) : base(controller) {}

    public override void EnterState()
    {
        
    }

    public override void UpdateState()
    {
        if (_enemy.CanSeePlayer())
        {
            _enemy.SetState(new ChasingState(_enemy));
        }
    }

    public override void ExitState()
    {
        
    }
}