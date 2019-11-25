using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillTracker : MonoBehaviour
{
    void Update()
    {
        GetComponent<Text>().text = "Kill: " + GameManager.Instance.KillCount;
    }
}
