using UnityEngine;
using System;
using System.Collections;

public class FieldOfView : MonoBehaviour
{
    
    [SerializeField] private LayerMask layerMask;
    public float detectionRange = 7.0f;
    public Transform targetTransform;
    public event Action<Transform> OnTargetEntered;
    public event Action OnTargetExited;


    private void Start()
    {
        StartCoroutine(FindPlayerInCirclePeriodically());
    }

    private IEnumerator FindPlayerInCirclePeriodically()
    {
        while (true)
        {   
            Collider2D hitCollider = Physics2D.OverlapCircle(transform.position, detectionRange, layerMask);
            bool hadTarget = targetTransform != null;
            bool hasTarget = hitCollider != null;

            if (hasTarget && !hadTarget)
            {
                targetTransform = hitCollider.transform;
                OnTargetEntered?.Invoke(targetTransform);
            }

            else if (!hasTarget && hadTarget)
            {
                targetTransform = null;
                OnTargetExited?.Invoke();
            }

            yield return new WaitForSeconds(0.3f);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
