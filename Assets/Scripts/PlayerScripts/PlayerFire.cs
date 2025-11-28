using System.Collections;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] Gun gun;
    [SerializeField] Transform firePosition;
    private Transform currentEnemy;


    private void OnEnable()
    {
        PlayerAimWithoutMouse playerAimWithoutMouse =  GetComponent<PlayerAimWithoutMouse>();
        playerAimWithoutMouse.OnGetCurrentEnemy += SetEnemy;
        playerAimWithoutMouse.OnAbsenceEnemy += DeleteEnemy;
    }

    private void OnDisable()
    {
        PlayerAimWithoutMouse playerAimWithoutMouse =  GetComponent<PlayerAimWithoutMouse>();
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
                FireAtEnemy();
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void FireAtEnemy()
    {
        if (currentEnemy == null) return;

        gun?.Fire(firePosition.position, currentEnemy.position);
    }
}
