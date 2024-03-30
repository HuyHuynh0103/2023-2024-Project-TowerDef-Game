using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public GameObject cornFort;
    public GameObject cannonFort;
    public GameObject slowForth;
    public GameObject PoisonFort;
    // Start is called before the first frame update
    void Start()
    {
        ShopData data = SaveSystem.LoadShop();
        if(data == null){
            cornFort.SetActive(true);
            cannonFort.SetActive(false);
            slowForth.SetActive(false);
            PoisonFort.SetActive(false);
        }else{
            cornFort.SetActive(data.IsCornBuy);
            cannonFort.SetActive(data.IsCannonBuy);
            slowForth.SetActive(data.IsSlowBuy);
            PoisonFort.SetActive(data.IsPoisonBuy);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
