using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private GunShootBullet gunShootBullet;

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
}
