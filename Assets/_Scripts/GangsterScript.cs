using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GangsterScript : MonoBehaviour
{
    public Transform target;
    public float speed = 3f;
    public float rotationSpeed = 0.0025f;
    private Rigidbody2D rb;
    public float distanceToShoot = 8f;
    public float distanceToStop = 6f;
    
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 15f;
    public float cooldown = 4f;
    public float timeBetweenShots = 0.5f;
    private float timeToShoot = 0f;
    private float rapidFire = 0f;
    private int secondShot = 0;


    private void Start()
    {
       rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!target)
        {
            GetTarget();
        }
        else
        {
            RotateTowardsTarget();
        }

        if (Vector2.Distance(target.position, transform.position) < distanceToShoot && timeToShoot <= 0)
        {
            Fire();

            timeToShoot = cooldown;

            rapidFire = 1f;
        }

        if (rapidFire >= 1 + timeBetweenShots && secondShot == 0)
        {
            Fire();

            secondShot = 1;
        }

        if (rapidFire >= 1 + 2 * timeBetweenShots)
        {
            Fire();

            rapidFire = 0;

            secondShot = 0;
        }

        if (rapidFire >= 1f)
        {
            rapidFire += Time.deltaTime;
        }

        if (timeToShoot > 0)
        {
            timeToShoot -= Time.deltaTime;
        }
    }

    private void Fire()
    {
        GameObject Bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(target.position, transform.position) >= distanceToStop)
        {
            rb.velocity = transform.up * speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void RotateTowardsTarget()
    {
        Vector2 targetDirection = target.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) *Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation , q, rotationSpeed);
    }

    private void GetTarget()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
}
