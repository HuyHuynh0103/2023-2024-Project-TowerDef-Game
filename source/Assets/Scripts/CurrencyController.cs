using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;


public class CurrencyController : MonoBehaviour
{
    public TMP_Text currency;
    // Update is called once per frame
    void Update()
    {
        currency.text = PlayerController.currency.ToString() + "$";
    }
}
