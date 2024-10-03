using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePower : MonoBehaviour
{
    public GameObject icePrefab;
    public Transform firePoint;
    public float fireForce = 10f;
    public IcePower icePower;
    public float cooldown = 1f;
    private float timeToShoot = 0;


    void Update()
    {
        if (timeToShoot > 0)
        {
            timeToShoot -= Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0) && timeToShoot <= 0)
        {
            icePower.Fire();

            timeToShoot = cooldown;
        }
    }

    public void Fire()
    {
        GameObject IcePower = Instantiate(icePrefab, firePoint.position, firePoint.rotation);
        IcePower.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }
}
