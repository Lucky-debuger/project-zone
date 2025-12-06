public class ChasingState : EnemyState
{
    public ChasingState(EnemyController controller) : base(controller){} // Почему нет возращаемого типа данных?

    public override void EnterState()
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState()
    {
        if (!_enemy.CanSeePlayer())
        {
            _enemy.SetState(new IdleState(_enemy)); // Зачем писать всегда new?
            return;
        }

        if (_enemy.CanSeePlayer())
        {
            _enemy.SetState(new AttackState(_enemy)); // Зачем передавать в качестве аргумента _enemy?
        }

        _enemy.MoveTowardsPlayer();
    }

    public override void ExitState()
    {
        throw new System.NotImplementedException();
    }
}
