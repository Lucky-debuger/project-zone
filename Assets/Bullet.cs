using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private void Update()
    {
        transform.localPosition += transform.right * moveSpeed * Time.deltaTime;
    }
}
