using UnityEngine;
using System;

public class FieldOfView : MonoBehaviour
{
    public bool isPlayerInArea = false;
    public Transform targetTransform;

    public event Action<Transform> OnTargetEntered;
    public event Action OnTargetExited;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            targetTransform = collider.transform;
            OnTargetEntered.Invoke(collider.transform); 
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            targetTransform = null;
            OnTargetExited.Invoke();
        }
    }
}
