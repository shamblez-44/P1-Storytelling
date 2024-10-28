using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CultBossAttackBullet : MonoBehaviour
{
    public int damage = 2;
    private float travelTime = 0f;
    public float maxTravelTime = 10f;

    private void Update()
    {
        travelTime += Time.deltaTime;

        if (travelTime >= maxTravelTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Health>(out var health) && collision.gameObject.CompareTag("Player"))
        {
            health.Damage(damage);

            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}