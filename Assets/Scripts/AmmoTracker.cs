using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoTracker : MonoBehaviour
{

    void Update()
    {
        GetComponent<Text>().text = 
            "Pistol: " + GameManager.Instance.PistolAmmoCount + "\n" +
            "Rifle: " + GameManager.Instance.AutomaticAmmoCount + "\n" +
            "Shotgun: " + GameManager.Instance.ShotgunAmmoCount;
    }
}
