using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBullet : MonoBehaviour
{
    public int damage = 3;
    public int speedDamage = 3;
    public float travelTime = 0f;

    private void Update()
    {
        travelTime += Time.deltaTime;

        if (travelTime >= 99f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

        if (collision.gameObject.TryGetComponent<Health>(out var health))
        {
            health.Damage(damage);
        }

        if (collision.gameObject.TryGetComponent<PlayerMovement>(out var speed))
        {
            speed.Damage(speedDamage);
        }
    }
}
