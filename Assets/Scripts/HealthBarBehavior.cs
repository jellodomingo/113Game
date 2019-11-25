using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarBehavior : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        this.transform.localScale = new Vector3(NormalizeHealth(),
            this.transform.localScale.y, this.transform.localScale.z);
    }

    private int NormalizeHealth()
    {
        float ratio = GameManager.Instance.PlayerHealth / 100f;
        Debug.Log(150 * ratio);
        return (int) (150f * ratio);
    }
}
