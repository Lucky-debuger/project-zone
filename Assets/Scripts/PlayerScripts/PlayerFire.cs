using System.Collections;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] GunShootBullet gunShootBullet;
    [SerializeField] Transform firePosition;
    [SerializeField] Transform aimRotation;
    private Transform currentEnemy;


    private void OnEnable()
    {
        PlayerAimWithoutMouse playerAimWithoutMouse = GetComponent<PlayerAimWithoutMouse>();
        playerAimWithoutMouse.OnGetCurrentEnemy += SetEnemy;
        playerAimWithoutMouse.OnAbsenceEnemy += DeleteEnemy;
    }

    private void OnDisable()
    {
        PlayerAimWithoutMouse playerAimWithoutMouse = GetComponent<PlayerAimWithoutMouse>();
        playerAimWithoutMouse.OnGetCurrentEnemy -= SetEnemy;
        playerAimWithoutMouse.OnAbsenceEnemy -= DeleteEnemy;
    }

    private void SetEnemy(Transform enemy)
    {
        currentEnemy = enemy;
    }

    private void DeleteEnemy()
    {
        currentEnemy = null;
    }

    private IEnumerator FirePeriodically()
    {
        while (true)
        {
            if (currentEnemy != null)
            {
                yield return new WaitForSeconds(0.09f);
                Fire();
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void Fire()
    {
        if (gunShootBullet != null)
        {
            gunShootBullet.Fire();
        }
    }
}
