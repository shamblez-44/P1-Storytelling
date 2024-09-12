using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEyes : MonoBehaviour
{
    public GameObject laserPrefab;
    public Transform firePoint;
    public float fireForce = 20f;
    public LaserEyes laserEyes;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            laserEyes.Fire();
        }
    }

    public void Fire()
    {
        GameObject laser = Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
        laser.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }
}
