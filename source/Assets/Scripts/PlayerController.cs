using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static int currency;
    public int startMoney = 400;
    public static int health = 0;
    public int startHealth = 20;

    public static string currentLevel = "";

    void Start () {
        currency = startMoney;
        health = startHealth;
    }
    
}
