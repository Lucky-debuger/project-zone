using UnityEngine;
using System;
using System.Collections;
using Unity.Mathematics;

public class FieldOfView : MonoBehaviour
{
    
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float detectionRange = 7.0f;

    public Transform targetTransform { get; private set; }
    public event Action<Transform> OnTargetEntered;
    public event Action OnTargetExited;

    private bool _playerInsideCollider = false;
    private bool _playerInsideColliderCurrentFrame = false;


    public void Initialize()
    {
        Debug.Log("1");
        StartCoroutine(FindPlayerInCirclePeriodically());
    }

    private IEnumerator FindPlayerInCirclePeriodically()
    {
        while (true)
        {   
            Collider2D hitCollider = Physics2D.OverlapCircle(transform.position, detectionRange, layerMask);
            _playerInsideColliderCurrentFrame = hitCollider != null;


            if (_playerInsideColliderCurrentFrame != _playerInsideCollider)
            {
                if (hitCollider)
                {
                    OnTargetEntered?.Invoke(hitCollider.transform);
                }
                else
                {
                    OnTargetExited?.Invoke();
                }
            }

            _playerInsideCollider = _playerInsideColliderCurrentFrame;


            // bool hadTarget = targetTransform != null;
            // bool hasTarget = hitCollider != null;

            // if (hasTarget && !hadTarget)
            // {
            //     targetTransform = hitCollider.transform;
            //     OnTargetEntered?.Invoke(targetTransform);
            // }

            // else if (!hasTarget && hadTarget)
            // {
            //     targetTransform = null;
            //     OnTargetExited?.Invoke();
            // }

            yield return new WaitForSeconds(0.3f);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
