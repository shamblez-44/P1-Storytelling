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
    private float timeToShoot = 0f;
    private float rapidFire = 0f;
    private bool secondShot = false;


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

            rapidFire = 0.01f;
        }

        if(rapidFire > 0)
        {
            rapidFire += Time.deltaTime;
        }

        if(timeToShoot > 0.2f && secondShot == false)
        {
            gunFire.Fire();

            secondShot = true;
        }

        if(timeToShoot > 0.4)
        {
            gunFire.Fire();

            rapidFire = 0;

            secondShot = false;
        }
    }

    public void Fire()
    {
        GameObject Bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }
}
