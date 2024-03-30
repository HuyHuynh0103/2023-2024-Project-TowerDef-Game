using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public TMP_Text healthText;
    

    // Update is called once per frame
    void Update()
    {
        healthText.text = "HP: " + PlayerController.health.ToString();
    }
}
