using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CultBossAttack2 : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed = 0.005f;
    private Rigidbody2D rb;

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 20f;
    public float cooldown = 1f;
    public float timeToShoot = 0f;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (timeToShoot <= 0)
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
