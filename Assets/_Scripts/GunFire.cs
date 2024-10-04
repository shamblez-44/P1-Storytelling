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
    }

    public void Fire()
    {
        GameObject Bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }
}
