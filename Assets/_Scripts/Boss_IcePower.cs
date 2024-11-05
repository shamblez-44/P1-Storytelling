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
    private float timeToIce = 0;
    public float speed = 5f;
    public float timeToShoot = 1f;
    private Rigidbody2D rb;
    public Animator animator;
    public float FireCooldown = 1;
    bool DoingAttack = false;
    public float distanceToStop = 6f;
    bool FacingRight = true;
    public SpriteRenderer Renderer;



    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    
    void Update()
    {
        if (target.position.x < transform.position.x && !FacingRight)
        {
            Flip();
        }
        if (target.position.x > transform.position.x && FacingRight)
        {
            Flip();
        }
        if (DoingAttack == true) 
        {
            timeToIce += 0.5f;
            timeToShoot += 0.5f;
            DoingAttack = false;
        }
        if (DoingAttack == false)
        {
            if (timeToShoot > 0)
            {
                timeToShoot -= Time.deltaTime;
            }
            if (timeToShoot <= 0)
            {
                Shoot();
                DoingAttack = true;
                timeToShoot = FireCooldown;
            }

            if (timeToIce > 0)
            {
                timeToIce -= Time.deltaTime;

            }
            if (timeToIce <= 0)
            {
                Ice();
                DoingAttack = true;
                timeToIce = cooldown;
                FireCooldown = 1;
            }
        }


        if (!target)
        {
            GetTarget();
        }
        else
        {
            RotateTowardsTarget();
        }
        animator.SetFloat("IcyPower", timeToIce);
        animator.SetFloat("Shoot",timeToShoot);
    }

    public void Ice()
    {
        GameObject IcePower = Instantiate(icePrefab, firePoint.position, firePoint.rotation);
        IcePower.GetComponent<Rigidbody2D>().AddForce(firePoint.up, ForceMode2D.Impulse);
    }

    private void Shoot()
    {
        GameObject Bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }
    
    private void FixedUpdate()

    {
        if (Vector2.Distance(target.position, transform.position) >= distanceToStop)
        {
            rb.velocity = transform.up * speed;
            animator.SetFloat("Moving",1f);
        }
        else
        {
            rb.velocity = Vector2.zero;
            animator.SetFloat("Moving", 0f);
        }
    }
  

    private void RotateTowardsTarget()
    {
        Vector2 targetDirection = target.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotationSpeed);

    }
    private void Flip()
    {
        FacingRight = !FacingRight;
        Renderer.flipX = FacingRight;
    }
    private void GetTarget()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
}

