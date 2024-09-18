using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public int damage = 5;
    public float travelTime = 0f;

    private void Update()
    {
        travelTime += Time.deltaTime;
        
        if (travelTime >= 3f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

        if(collision.gameObject.TryGetComponent<Health>(out var health))
        {
            health.Damage(damage);
        }
    }
}
