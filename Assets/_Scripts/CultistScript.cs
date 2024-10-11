using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CultistScript : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed = 0.0025f;
    private Rigidbody2D rb;
    public float distanceToShoot = 8f;

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 15f;
    public float cooldown = 4f;
    private float timeToShoot = 0f;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Vector2.Distance(target.position, transform.position) < distanceToShoot && timeToShoot <= 0)
        {
            Fire();

            timeToShoot = cooldown;
        }

        if (timeToShoot > 0)
        {
            timeToShoot -= Time.deltaTime;
        }

        RotateTowardsTarget();
    }

    private void Fire()
    {
        GameObject Bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }

    private void RotateTowardsTarget()
    {
        Vector2 targetDirection = target.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotationSpeed);
    }
}