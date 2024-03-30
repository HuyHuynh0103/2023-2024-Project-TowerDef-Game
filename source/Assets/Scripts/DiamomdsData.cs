using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DiamomdsData
{
    public int diamonds;

    public DiamomdsData(){
        diamonds = ShopMenu.diamonds;
    }
}
