using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_IcePower : MonoBehaviour
{
    public GameObject icePrefab;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Transform target;
    public float fireForce = 10f;
    public float rotationSpeed = 0.0025f;
    public float cooldown = 10f;
    private float timeToShoot = 0;
    public float speed = 5f;
    public float timeToFire = 1f;
    private Rigidbody2D rb;
    public Animator animator;

    

    void Update()
    {
        if (timeToShoot > 0)
        {
            timeToShoot -= Time.deltaTime;
            
        }
        if (timeToFire <=0)
        {
            Shoot();
        }
        if (timeToFire > 0)
        {
            timeToFire -= Time.deltaTime;
        }

        if (timeToShoot <= 0)
        {
            Fire();

            timeToShoot = cooldown;


        }

        if (!target)
        {
            GetTarget();
        }
        else
        {
            RotateTowardsTarget();
        }
        animator.SetFloat("IcyPower", timeToShoot);
        animator.SetFloat("Shoot",timeToFire);
    }

    public void Fire()
    {
        GameObject IcePower = Instantiate(icePrefab, firePoint.position, firePoint.rotation);
        IcePower.GetComponent<Rigidbody2D>().AddForce(firePoint.up, ForceMode2D.Impulse);
    }

    private void Shoot()
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
    private void GetTarget()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
}

