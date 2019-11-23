using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawning : MonoBehaviour
{
    public GameObject Zombie;
    public int ZombieCount = 10;


    // Start is called before the first frame update
    void Start()
    {
        SpawnZombie();
        SpawnZombie();
        SpawnZombie();
    }

    // Update is called once per frame
    void Update()
    {
        //Keep Number of Zombies on Field to ZombieCount
        if (transform.GetChild(4).childCount <= ZombieCount)
        {
            SpawnZombie();
        }
        

    }

    void SpawnZombie()
    {
        Transform spawn = this.transform.GetChild(Random.Range(0,4)).transform;

        GameObject z = Instantiate(Zombie, spawn.position, spawn.rotation);

        z.transform.parent = this.transform.GetChild(4);
    }


}
