using System;
using UnityEngine;


public class PlayerAimWithoutMouse : MonoBehaviour
{
    [SerializeField] private Gun currentWeapon;
    private Transform aimTransform;
    private Transform firePos;
    private Transform target;

    private float testTimerFire = 2.0f;
   
    private void Awake()
    {
        aimTransform = transform.Find("Aim");
        firePos = transform.Find("Aim/Pistol/FirePos");
    }

    private void Update()
    {
        if (target == null) return;
        Debug.Log(target);

        HandleAiming(target.position);
        TestFire();
    } 

private void TestFire()
{
    testTimerFire -= Time.deltaTime;
    
    if (testTimerFire > 0) return;
    
    if (target != null)
    {
        HandleShooting(target.position);
    }
    testTimerFire = 2.0f;
}

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            target = collider.transform;
            Debug.Log(target);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            target = null;
        }
    }

    private void HandleAiming(Vector2 aimPosition)
    {
        Vector3 targetPos = new Vector3(aimPosition.x, aimPosition.y, 0);
        Vector3 aimDirection = (targetPos - aimTransform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);

        Vector3 aimLocalScale = Vector3.one;
        if (angle > 90 || angle < -90)
        {
            aimLocalScale.y = -1f;
        }
        else
        {
            aimLocalScale.y = +1f;
        }
        aimTransform.localScale = aimLocalScale;
    }



    private void HandleShooting(Vector2 mouseClickPosition)
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mouseClickPosition);
        worldPosition.z = 0;

        currentWeapon?.Fire(firePos.position, worldPosition);
    }
}
