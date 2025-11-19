using System.Collections;
using UnityEngine;

public class BulletTracer : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector3 startPosition;
    private Vector3 endPosition;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void CreateBulletTracer(Vector3 fromPosition, Vector3 targetPosition)
    {
        Debug.Log($"BulletTracer position: {fromPosition}, {targetPosition}");
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
