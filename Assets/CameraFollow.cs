using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void Start()
    {
        target.GetComponent<HealthSystem>().OnDied += OnDied;
    }

    private void OnDied()
    {
        enabled = false;
    }

    void LateUpdate()
    {
        var target_position = target.position;
        target_position.z = -10.0f;
        transform.position = target_position;
    }
}