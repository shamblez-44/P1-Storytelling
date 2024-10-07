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
    public float timeToShoot = 0f;
    public float rapidFire = 0f;
    public int secondShot = 0;


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

        if(timeToShoot >= 1.2f && secondShot == 0)
        {
            gunFire.Fire();

            secondShot = 1;
        }

        if(timeToShoot >= 1.4)
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
