using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Movement : MonoBehaviour

{
    private Rigidbody2D rb;
    public float speed = 5f;
    public float distanceToStop = 6f;
    public Transform target;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (Vector2.Distance(target.position, transform.position) >= distanceToStop)
        {
            rb.velocity = Vector2.MoveTowards(transform.position,target.position,speed * Time.deltaTime);   
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void GetTarget()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
   
}
