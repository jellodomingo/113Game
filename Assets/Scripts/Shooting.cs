using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet; //Bullet Prefab

    public float bulletForce = 20f;

    private float FireRate = 10;
    private float lastfired;

    private int WeaponState = 0;

    // Update is called once per frame
    void Update()
    {
        WeaponCheck();
        switch (WeaponState)
        {
            case 0:
                SingleShot();
                break;
            case 1:
                AutomaticShot();
                break;
            case 2:
                ShotgunShot();
                break;
        }
    }

    void WeaponCheck()
    {
        this.transform.GetChild(WeaponState).gameObject.SetActive(false);
        WeaponInputCheck();
    }

    void WeaponInputCheck()
    {
        if (Input.GetKey("1"))
        {
            WeaponState = 0;
        }

        if (Input.GetKey("2"))
        {
            WeaponState = 1;
        }

        if (Input.GetKey("3"))
        {
            WeaponState = 2;
        }

        this.transform.GetChild(WeaponState).gameObject.SetActive(true);
    }

    void Shoot()
    {
        //Spawn bullet
        GameObject b = Instantiate(bullet, transform.position, transform.rotation);
        Rigidbody2D rb = b.GetComponent<Rigidbody2D>();

        //Add force to up vector
        //Debug.Log(firePoint.up);
        rb.AddForce(transform.up * bulletForce, ForceMode2D.Impulse);
    }

    void SingleShot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();    
        }
    }

    void AutomaticShot()
    {
        if (Input.GetButton("Fire1"))
        {
            if (Time.time - lastfired > 1 / FireRate)
            {
                lastfired = Time.time;
                Shoot();
            }
        }
    }

    void ShotgunShot()
    {
        Debug.Log("POW");
    }
}
