using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public int damage = 5;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

        if(collision.gameObject.TryGetComponent<Health>(out var health))
        {
            health.Damage(damage);
        }
    }
}
