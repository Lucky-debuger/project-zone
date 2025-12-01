using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float lifeTime;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        transform.localPosition += transform.right * moveSpeed * Time.deltaTime;
    }

    public void SetInitialDirection(float spreadAngle)
    {
        float baseAngle = transform.rotation.eulerAngles.z;
        float randomOffset = Random.Range(-spreadAngle / 2, spreadAngle / 2);
        float finalAngle = baseAngle + randomOffset;
        transform.rotation = Quaternion.Euler(0, 0, finalAngle);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            damageable.GetDamage(25.0f);
            Destroy(gameObject);
        }
    }
}
