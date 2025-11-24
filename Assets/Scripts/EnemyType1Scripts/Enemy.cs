using UnityEngine;


public class Enemy : MonoBehaviour, IDamageable
{
    public float moveSpeed = 2f;

    private Rigidbody2D rb;
    private Transform target;
    private FieldOfView FOV;
    private Vector2 moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        FOV = GetComponentInChildren<FieldOfView>();

        FOV.OnTargetEntered += GetTarget;
        FOV.OnTargetExited += RemoveTarget;
    }

    private void FixedUpdate() // Зачем FixedUpdate
    {
        if (!target) return;

        ChaseTarget(target.position);
    }

    private void ChaseTarget(Vector2 targetPosition)
    {
        moveDirection = GetDirectionOnTarget(target.position);
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
    }

    private Vector2 GetDirectionOnTarget(Vector3 targetPosition)
    {
        Vector2 direction = (targetPosition - transform.position).normalized;
        return direction;
    }

    private void GetTarget(Transform targetTransform)
    {
        target = targetTransform;
    }

    private void RemoveTarget()
    {
        target = null;
        rb.velocity = Vector2.zero;
    }

    public void GetDamage(float countDamage)
    {
        Debug.Log("Я получил урон: " + countDamage.ToString());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 7);
    }
}
