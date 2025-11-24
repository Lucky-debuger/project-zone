using System;
using System.Collections.Generic;
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
        firePos = transform.Find("Aim/Pistol/FirePos"); // Стоит ли так делать?
    }

    private void Update()
    {
        GetNearestTarget();
        if (target != null)
        {
            HandleAiming(target.position);
        }

        // HandleAiming(target.position);
        // TestFire();
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

    private Dictionary<Transform, float> distanceToTargets = new Dictionary<Transform, float>();

    private void GetNearestTarget()
    {
        if (distanceToTargets.Count == 0)
        {
            target = null; 
            return;
        }

        foreach (Transform key in distanceToTargets.Keys)
        {
            Debug.Log(key);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            target = collider.transform;
            distanceToTargets.Add(collider.transform, Mathf.Infinity);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            distanceToTargets.Remove(target);
        }
    }

    private void HandleAiming(Vector3 aimPosition)
    {
        Vector3 aimDirection = (aimTransform.position - aimPosition).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg + 180;
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
