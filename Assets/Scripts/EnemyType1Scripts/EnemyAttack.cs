using UnityEditor.Rendering;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] FieldOfView fieldOfView;
    [SerializeField] float attackDistance;
    [SerializeField] float attackInterval;

    private float timerAttack = 0.0f;

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
        if (currentTarget && CheckTargetInAttackArea())
        {
            timerAttack += Time.fixedDeltaTime;

            if (timerAttack >= attackInterval)
            {
                if (CheckTargetInAttackArea()) Attack();

                timerAttack = 0.0f;
            }   
        }
        else
        {
            timerAttack = 0.0f;
        }


    }

    private void Attack()
    {
        if (currentTarget.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            damageable.GetDamage(25.0f);
        }
    }

    private bool CheckTargetInAttackArea()
    {
        float distanceToTarget = Vector3.Distance(currentTarget.position, transform.position);

        if (distanceToTarget <= attackDistance)
        {
            return true;
        }
        
        return false;
    }
}
