using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint; //Spawnpoint of bullet
    public GameObject bullet; //Bullet Prefab

    public float bulletForce = 20f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        //Spawn bullet
        GameObject b = Instantiate(bullet, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = b.GetComponent<Rigidbody2D>();

        //Add force to up vector
        //Debug.Log(firePoint.up);
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
