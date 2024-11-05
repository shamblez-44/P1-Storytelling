using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float maxSpeed = 5f;
    private float speedCooldown = 0f;
    private float inputX;
    private float inputY;
    Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    //public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");

        if (speed < maxSpeed)
        {
            speedCooldown += Time.deltaTime;
        }

        if (speedCooldown >= 3f)
        {
            speed = maxSpeed;

            speedCooldown = 0f;
        }
       // animator.SetFloat("Walk", speed);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(inputX*speed, inputY*speed);
    }

    public void Damage(int amount) => speed -= amount;
}
