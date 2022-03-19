using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletPerfab;
    public Transform firePoint;

    public float fireTimeGap = 0.3f;
    private float fireTimer;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPerfab, firePoint.position, Quaternion.identity);
            fireTimer = fireTimeGap;
        }

        if (fireTimer < 0 &&
            Input.GetKey(KeyCode.Space))

        {
            Instantiate(bulletPerfab, firePoint.position, Quaternion.identity);
            fireTimer = fireTimeGap;
        }
        else
            fireTimer -= Time.deltaTime;
    }
}
