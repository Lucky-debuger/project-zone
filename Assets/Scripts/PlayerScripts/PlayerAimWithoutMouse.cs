using System;
using UnityEngine;


public class PlayerAimWithoutMouse : MonoBehaviour
{
    [SerializeField] private Transform aim;
    [SerializeField] private Transform gun;
    [SerializeField] private float gunScale = 3.0f;
    [SerializeField] private float detectionUpdateInterval = 0.5f;
    [SerializeField] private float detectionRange = 7.0f;
    public Transform currentEnemy;
    public event Action<Transform> OnGetCurrentEnemy;
    public event Action OnAbsenceEnemy;

    private void Start()
    {
        StartCoroutine(GetNearestEnemyPeriodically());
    }

    private void Update()
    {
        AimOnNearestEnemy();
    }

    
    private Transform GetNearestEnemyInCircle()
    {
        Collider2D[] hitCollider = Physics2D.OverlapCircleAll(transform.position, detectionRange);
        Transform nearestEnemy = null;
        float nearestSqrDistance = Mathf.Infinity;

        foreach (var collider in hitCollider)
        {
            if (collider.CompareTag("Enemy"))
            {
                float sqrDistance = (transform.position - collider.transform.position).sqrMagnitude;
                if (sqrDistance < nearestSqrDistance)
                {
                    nearestSqrDistance = sqrDistance;
                    nearestEnemy = collider.transform;
                }
            }
        }
        
        return nearestEnemy;
    }

    private System.Collections.IEnumerator GetNearestEnemyPeriodically()
    {
        while (true)
        {
            currentEnemy = GetNearestEnemyInCircle();
            yield return new WaitForSeconds(detectionUpdateInterval);
        }
    }

    private float GetAngleOnEnemy(Transform enemy)
    {
        if (enemy == null) return 0f;

        Vector3 direction = (enemy.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        return angle;
    }

    private void AimOnNearestEnemy()
    {
        if (currentEnemy == null)
        {
            OnAbsenceEnemy?.Invoke();
            return;
        } 

        float angle = GetAngleOnEnemy(currentEnemy);
        FlipGun(angle);
        aim.eulerAngles = new Vector3(0, 0, angle);
        OnGetCurrentEnemy?.Invoke(currentEnemy);
    }

    private void FlipGun(float angle)
    {
        Vector3 newScale = gun.localScale;

        if (angle < 90 && angle > -90)
        {
            newScale.y = gunScale;
        }
        else
        {
            newScale.y = -gunScale;
        }
        
        gun.localScale = newScale;
    }

    
}
