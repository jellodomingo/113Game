using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoxBehavior : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.PlayerHealthUp(30);
            Destroy(this.gameObject);
        }
        else
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>(), true);
        }
    }
}
