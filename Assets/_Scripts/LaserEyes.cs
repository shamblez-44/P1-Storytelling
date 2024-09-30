using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEyes : MonoBehaviour
{
    public GameObject laserPrefab;
    public Transform firePoint;
    public float fireForce = 20f;
    public LaserEyes laserEyes;
    public float cooldown = 0.5f;
    private float timeToShoot = 0;


    void Update()
    {
        if (timeToShoot > 0)
        {
            timeToShoot -= Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0) && timeToShoot <= 0)
        {
            laserEyes.Fire();

            timeToShoot = cooldown;
        }
    }

    public void Fire()
    {
        GameObject laser = Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
        laser.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }
}
