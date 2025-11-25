using UnityEngine;


public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private float moveSpeed = 2.0f;

    private Rigidbody2D rb;
    private Transform target;
    private FieldOfView FOV;
    private Vector2 moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        FOV = GetComponentInChildren<FieldOfView>();

        if (rb == null) Debug.LogError("RigidBody2D not found on Enemy!");
        if (FOV == null) Debug.LogError("FOV not found in children");

        FOV.OnTargetEntered += GetTarget;
        FOV.OnTargetExited += RemoveTarget;
    }

    private void Update()
    {
        if (target == null || !target.gameObject.activeInHierarchy)
        {
            moveDirection = Vector2.zero;
            RemoveTarget();
            return;
        }
            moveDirection = (target.position - transform.position).normalized;
    }

    private void FixedUpdate()
    {
        if (target == null) return;
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
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

    private void OnDestroy()
    {
        FOV.OnTargetEntered -= GetTarget;
        FOV.OnTargetExited -= RemoveTarget;
    }
}
