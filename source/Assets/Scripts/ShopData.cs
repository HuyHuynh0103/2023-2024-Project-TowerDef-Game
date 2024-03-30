using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShopData
{
    public bool IsCannonBuy;
    public bool IsCornBuy;
    public bool IsSlowBuy;
    public bool IsPoisonBuy;
    //public int diamonds;

    public ShopData(){
        IsCannonBuy = ShopMenu.IsCannonBuy;
        IsCornBuy = ShopMenu.IsCornBuy;
        IsSlowBuy = ShopMenu.IsSlowBuy;
        IsPoisonBuy = ShopMenu.IsPoisonBuy;
       // diamonds = ShopMenu.diamonds;
    }
}
