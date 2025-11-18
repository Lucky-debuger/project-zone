using System.Collections;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class BulletTracer : MonoBehaviour
{
    // [SerializeField] private LineRenderer lineRenderer;
    private LineRenderer lineRenderer;
    private Vector3 startPosition;
    private Vector3 endPosition;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void CreateWeaponTracer(Vector3 fromPosition, Vector3 targetPosition)
    {
        startPosition = fromPosition;
        endPosition = targetPosition;

        StartCoroutine(AnimateTracer());
    }

    private IEnumerator AnimateTracer()
    {
        float duration = 0.1f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float progress = elapsed / duration;

            Vector3 currentEnd = Vector3.Lerp(startPosition, endPosition, progress);

            lineRenderer.SetPosition(0, startPosition);
            lineRenderer.SetPosition(1, currentEnd);

            yield return null;
        }

        lineRenderer.SetPosition(0, startPosition);
        lineRenderer.SetPosition(1, endPosition);

        Destroy(gameObject, 0.05f);
    }
}
