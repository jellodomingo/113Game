using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet; //Bullet Prefab

    public float bulletForce = 100f;

    private float AutomaticFireRate = 10;
    private float lastfired;

    private int WeaponState = 0;

    // Update is called once per frame
    void Update()
    {
        WeaponCheck();
        switch (WeaponState)
        {
            case 0:
                if (checkAmmo(WeaponState))
                {
                    SingleShot();
                }
                
                break;
            case 1:
                if (checkAmmo(WeaponState))
                {
                    AutomaticShot();
                }
                
                break;
            case 2:
                if (checkAmmo(WeaponState))
                {
                    ShotgunShot();
                }
                
                break;
        }
    }

    private bool checkAmmo(int weapon)
    {
        return GameManager.Instance.CanShoot(weapon);
    }

    private void WeaponCheck()
    {
        this.transform.GetChild(WeaponState).gameObject.SetActive(false);
        WeaponInputCheck();
    }

    private void WeaponInputCheck()
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

    private void SpreadShoot()
    {
        //Spawn bullet
        GameObject b = Instantiate(bullet, transform.position, transform.rotation);
        Rigidbody2D rb = b.GetComponent<Rigidbody2D>();

        //Add force to up vector
        //Debug.Log(firePoint.up);
        b.transform.Rotate(0, 0, Random.Range(-30, 30));
        rb.AddForce(b.transform.up * bulletForce, ForceMode2D.Impulse);

        
        
    }

    private void SingleShot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            GameManager.Instance.AmmoDown(0, 1);
        }
    }

    private void AutomaticShot()
    {
        if (Input.GetButton("Fire1"))
        {
            if (Time.time - lastfired > 1 / AutomaticFireRate)
            {
                lastfired = Time.time;
                Shoot();
                GameManager.Instance.AmmoDown(1, 1);
            }
        }
    }

    private void ShotgunShot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SpreadShoot();
            SpreadShoot();
            SpreadShoot();
            SpreadShoot();
            SpreadShoot();
            GameManager.Instance.AmmoDown(2, 1);
        }
    }
}
