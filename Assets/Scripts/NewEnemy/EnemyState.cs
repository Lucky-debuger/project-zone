public abstract class EnemyState
{
    protected EnemyController _enemy; // Почему нет у классов наследников?

    public EnemyState(EnemyController controller)
    {
        _enemy = controller;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
}
