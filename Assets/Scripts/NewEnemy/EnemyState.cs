public abstract class EnemyState
{
    protected EnemyController _enemy;

    public EnemyState(EnemyController controller)
    {
        _enemy = controller;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
}
