using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class DiamondsController : MonoBehaviour
{
    public TMP_Text diamonds;

    // Update is called once per frame
    void Update()
    {
        diamonds.text = "Diamonds: " + ShopMenu.diamonds.ToString();
    }
}
