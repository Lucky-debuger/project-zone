using UnityEngine;

public class BulletTracer : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;

    // private void Awake()
    // {
    //     lineRenderer = GetComponent<LineRenderer>();
    // }
    public void CreateWeaponTracer(Vector3 fromPosition, Vector3 targetPosition)
    {
        lineRenderer.SetPosition(0, fromPosition);
        lineRenderer.SetPosition(1, targetPosition);

        Destroy(gameObject, 1f);
    }
}
