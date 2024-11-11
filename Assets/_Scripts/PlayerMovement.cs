using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
    private bool FacingRight = true;
    public SpriteRenderer Renderer;
    public Animator animator;
    //public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (speed < maxSpeed)
        {
            speedCooldown += Time.deltaTime;
        }

        if (speedCooldown >= 3f)
        {
            speed = maxSpeed;

            speedCooldown = 0f;
        }
        if (mousePos.x < transform.position.x && !FacingRight)
        {
            Flip();
        }
        if (mousePos.x > transform.position.x && FacingRight)
        {
            Flip();
        }
        // animator.SetFloat("Walk", speed);
        if (rb.velocity.x != 0 || rb.velocity.y != 0)
        {
            animator.SetFloat("Run", 1);
        }
        else
        {
            animator.SetFloat("Run", 0);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(inputX*speed, inputY*speed);
    }

    public void Damage(int amount) => speed -= amount;
    private void Flip()
    {
        FacingRight = !FacingRight;
        Renderer.flipX = !Renderer.flipX;
    }
}
