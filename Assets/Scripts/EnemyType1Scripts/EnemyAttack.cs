using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] FieldOfView fieldOfView;
    [SerializeField] float attackDistance;
    [SerializeField] float attackInterval;

    private float timerAttack = 0.0f;
    private bool _isInAttackState = false;
    private bool _isInAttackArea = false;
    private Transform currentTarget = null;

    private void Start()
    {
        fieldOfView.OnTargetEntered += OnTargetEntered;
        fieldOfView.OnTargetExited += OnTargetExited;
    }

    private void OnTargetEntered(Transform target) => currentTarget = target;
    
    private void OnTargetExited() => currentTarget = null;

    private void FixedUpdate()
    {
        timerAttack += Time.fixedDeltaTime;

        if (timerAttack >= attackInterval)
        {
            _isInAttackState = true;
        }

        if (currentTarget)
        {
            if (_isInAttackState)
            {
                if (CheckInAttackArea() != true) return;
                
                Attack();
                timerAttack = 0.0f;
                _isInAttackState = false;
            }
        }
    }

    private void Attack()
    {
        if (currentTarget.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            damageable.GetDamage(25.0f);
        }
    }

    private bool CheckInAttackArea()
    {
        float distanceToTarget = Vector3.Distance(currentTarget.position, transform.position);

        if (distanceToTarget <= attackDistance)
        {
            return true;
        }
        
        return false;
    }
}
