using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private bool canTakeDamage = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            if (canTakeDamage)
            {
                Debug.Log("take damage");
                StartCoroutine(WaitForSeconds());
                GameManager.Instance.PlayerHealthDown(collision.gameObject.GetComponent<EnemyAI>().AttackPower);
            }
            
        }
    }

    IEnumerator WaitForSeconds()
    {
        canTakeDamage = false;
        yield return new WaitForSecondsRealtime(1);
        canTakeDamage = true;
    }
}
