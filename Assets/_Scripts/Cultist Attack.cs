using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CultistAttack : MonoBehaviour
{
    public int damage = 10;
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
        Destroy(gameObject);

        if (collision.gameObject.TryGetComponent<Health>(out var health) && collision.gameObject.CompareTag("Player"))
        {
            health.Damage(damage);
        }
    }
}
