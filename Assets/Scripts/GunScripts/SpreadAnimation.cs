using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadAnimation : MonoBehaviour
{
    [SerializeField] private GunShootBullet gunShootBullet;
    [SerializeField] private Transform pivotUp;
    [SerializeField] private Transform pivotDown;
    private float spreadAngle;


    void Update()
    {
        spreadAngle = gunShootBullet.spreadAngle;
        pivotUp.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + spreadAngle/2);
        pivotDown.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z - spreadAngle/2);
    }
}
