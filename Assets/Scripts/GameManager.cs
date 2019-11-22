﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    /*
     * Keep track of:
     * - Level
     * - Health
     * - Abilites
     * - Score
     * 
    */
    public static GameManager Instance { get; private set; } 

    public GameObject player;

    void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
