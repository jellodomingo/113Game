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

    public int KillCount = 0;

    public int PlayerHealth = 100;

    public int MAX_PISTOL_AMMO = 30;
    public int MAX_AR_AMMO = 100;
    public int MAX_SHOTGUN_AMMO = 15;

    public int PistolAmmoCount = 30;
    public int AutomaticAmmoCount = 50;
    public int ShotgunAmmoCount = 5;


    public int dropRate = 10; //Outta of hundred

    private bool GameOver = false;

    void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }

    }

    private void Update()
    {
        if (CheckPlayerHealth())
        {
            player.SetActive(false);
            GameOver = true;
            // Add retry button
        }
    }

    //Player Health Up
    public void PlayerHealthUp(int amount)
    {
        //TODO: Cap health
        int newHealth = PlayerHealth + amount;
        PlayerHealth = newHealth >= 100 ? 100 : newHealth;
    }

    //Player Health Down
    public void PlayerHealthDown(int amount)
    {
        //TODO: Cap health to 0

        int newHealth = PlayerHealth - amount;
        PlayerHealth = newHealth <= 0 ? 0 : newHealth;
    }

    //Ammo Up
    public void AmmoUp(int weapon,int amount)
    {
        //TODO: Cap ammo
        int newAmmo;

        switch (weapon)
        {
            case 0:
                newAmmo = PistolAmmoCount + amount;
                PistolAmmoCount = newAmmo >= MAX_PISTOL_AMMO ? MAX_PISTOL_AMMO : newAmmo;

                break;
            case 1:
                newAmmo = AutomaticAmmoCount + amount;
                AutomaticAmmoCount = newAmmo >= MAX_AR_AMMO ? MAX_AR_AMMO : newAmmo;
                break;
            case 2:
                newAmmo = PistolAmmoCount + amount;
                ShotgunAmmoCount = newAmmo >= MAX_SHOTGUN_AMMO ? MAX_SHOTGUN_AMMO : newAmmo;
                break;
        }

    }

    //Ammo Down
    public void AmmoDown(int weapon, int amount)
    { 
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

    //Checks if out of Ammo
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

    //Raises kill score up by 1
    public void KillUp()
    {
        KillCount++;
    }

    //Chance to drop
    public bool ShouldDrop()
    {
        int rand = Random.Range(0, 100);
        if (rand <= dropRate) return true;
        else return false;
    }

    private bool CheckPlayerHealth()
    {
        if (PlayerHealth <= 0)
        {
            return true;
        }
        else return false;
    }

}
