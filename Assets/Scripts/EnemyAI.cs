using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyAI : MonoBehaviour
{

    public int MinDist = 3;
    public int MaxDist = 100;
    public float MoveSpeed = 4f;



    // Start is called before the first frame update
    void Start()
    {
        //Find player location
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(GameManager.Instance.player.transform);

        if (Vector3.Distance(transform.position, GameManager.Instance.player.transform.position) >= MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;



            if (Vector3.Distance(transform.position, GameManager.Instance.player.transform.position) <= MaxDist)
            {
                //Here Call any function U want Like Shoot at here or something
            }
        }
    }
    
}
