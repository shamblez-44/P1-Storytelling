using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstFight : MonoBehaviour
{
    public Transform player;
    public Transform spawnPoint;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        player.position = spawnPoint.position;
    }
}
