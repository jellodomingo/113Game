using System.Collections;
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
     * - Zombie Kill Count
     *
    */
    public static GameManager Instance { get; private set; } 

    public GameObject player;

    public int PlayerHealth = 100;

    public int PistolAmmoCount = 30;
    public int AutomaticAmmoCount = 100;
    public int ShotgunAmmoCount = 10;

    void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }

    }

    //Player Health Up
    public void PlayerHealthUp(int amount)
    {
        //TODO: Cap health

        PlayerHealth += amount;
    }

    //Player Health Down
    public void PlayerHealthDown(int amount)
    {
        //TODO: Cap health to 0

        PlayerHealth -= amount;
    }

    //Ammo Up
    public void AmmoUp(int weapon,int amount)
    {
        //TODO: Cap ammo
        switch (weapon)
        {
            case 0:
                PistolAmmoCount += amount;

                break;
            case 1:
                AutomaticAmmoCount += amount;

                break;
            case 2:
                ShotgunAmmoCount += amount;
                break;
        }

    }

    //Ammo Down
    public void AmmoDown(int weapon, int amount)
    {
        //TODO: Cap ammo to 0

        switch (weapon)
        {
            case 0:
                PistolAmmoCount -= amount;

                break;
            case 1:
                AutomaticAmmoCount -= amount;

                break;
            case 2:
                ShotgunAmmoCount -= amount;
                break;
        }
    }

    public bool CanShoot(int weapon)
    {
        switch (weapon)
        {
            case 0:
                if (PistolAmmoCount <= 0) return false;
                else return true;

            case 1:
                if (AutomaticAmmoCount <= 0) return false;
                else return true;
;
            case 2:
                if (ShotgunAmmoCount <= 0) return false;
                else return true;

            default:
                return false;

        }
    }


    public void DisplayStatus()
    {
        Debug.Log("Player Health: " + PlayerHealth);
        Debug.Log("Pistol Ammo: " + PistolAmmoCount);
        Debug.Log("AR Ammo: " + AutomaticAmmoCount);
        Debug.Log("Shotgun Ammo: " + ShotgunAmmoCount);

    }

}
