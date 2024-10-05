using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_IcePower : MonoBehaviour
{
    public GameObject icePrefab;
    public Transform firePoint;
    public float fireForce = 10f;
    public float cooldown = 10f;
    private float timeToShoot = 0;
    private GameObject Player;

    private void Start()
    {

        Player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = Player.transform.position - transform.position;
    }

    void Update()
    {
        if (timeToShoot > 0)
        {
            timeToShoot -= Time.deltaTime;
        }

        if (timeToShoot <= 0)
        {
            Fire();

            timeToShoot = cooldown;


        }
        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void Fire()
    {
        GameObject IcePower = Instantiate(icePrefab, firePoint.position, firePoint.rotation);
        IcePower.GetComponent<Rigidbody2D>().AddForce(firePoint.up, ForceMode2D.Impulse);
    }
}
