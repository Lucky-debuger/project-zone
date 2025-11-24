using UnityEngine;
using System;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] private float detectionRange = 7.0f;
    [SerializeField] private LayerMask layerMask;
    public Transform targetTransform;
    public event Action<Transform> OnTargetEntered;
    public event Action OnTargetExited;


    private void Update()
    {
        FindPlayerInCircle();
    }

    private void FindPlayerInCircle()
    {
        Collider2D hitCollider = Physics2D.OverlapCircle(transform.position, detectionRange, layerMask);

        if (hitCollider == null)
        {
            OnTargetExited?.Invoke();
            targetTransform = null;
            return;
        }

        OnTargetEntered?.Invoke(hitCollider.transform);
        targetTransform =  hitCollider.transform;
    }
}
