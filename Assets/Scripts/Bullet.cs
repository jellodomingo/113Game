using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Can add bullet collision effect here
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Drop")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>(), true);
        }
        else if (collision.gameObject.tag == "Zombie")
        {
            collision.gameObject.SendMessage("HealthDown", 10);
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
            
    }
}
