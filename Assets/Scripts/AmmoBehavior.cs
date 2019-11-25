using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBehavior : MonoBehaviour
{
    public int PistolAmmoGain = 20;
    public int ARAmmoGain = 30;
    public int ShotgunAmmoGain = 5;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int weapon = Random.Range(0, 3);

            switch (weapon)
            {
                case 0:
                    GameManager.Instance.AmmoUp(weapon, PistolAmmoGain);
                    break;
                case 1:
                    GameManager.Instance.AmmoUp(weapon, ARAmmoGain);
                    break;
                case 2:
                    GameManager.Instance.AmmoUp(weapon, ShotgunAmmoGain);
                    break;
            }
            
            Destroy(this.gameObject);
        }
        else
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        }
    }
}
