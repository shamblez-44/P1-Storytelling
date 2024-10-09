using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public GunFire gunFire;
    public float fireForce = 20f;
    public float cooldown = 4f;
    public float timeBetweenShots = 0.5f;
    private float timeToShoot = 0f;
    private float rapidFire = 0f;
    private int secondShot = 0;


    void Update()
    {
        if (timeToShoot > 0)
        {
            timeToShoot -= Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0) && timeToShoot <= 0)
        {
            gunFire.Fire();

            timeToShoot = cooldown;

            rapidFire = 1f;
        }

        if(rapidFire >= 1f)
        {
            rapidFire += Time.deltaTime;
        }

        if(rapidFire >= 1+timeBetweenShots && secondShot == 0)
        {
            gunFire.Fire();

            secondShot = 1;
        }

        if(rapidFire >= 1+2*timeBetweenShots)
        {
            gunFire.Fire();

            rapidFire = 0;

            secondShot = 0;
        }
    }

    public void Fire()
    {
        GameObject Bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }
}
