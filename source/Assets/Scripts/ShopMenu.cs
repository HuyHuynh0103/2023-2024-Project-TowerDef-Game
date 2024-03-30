using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    public SceneFader levelFader;
    public GameObject cornFort;
    public GameObject cannonFort;
    public GameObject slowFort;
    public GameObject poisonFort;

    public static bool IsCannonBuy = false;
    public static bool IsCornBuy = true;
    public static bool IsSlowBuy = false;
    public static bool IsPoisonBuy = false;
    public static int diamonds = 50;


    private void Start() {
        DiamomdsData diamondsData = SaveSystem.LoadDiamonds();
        if(diamondsData == null){
            diamonds = 50;
        }else{
            diamonds = diamondsData.diamonds;
        }
        ShopData data = SaveSystem.LoadShop();
        if(data == null){
            IsCannonBuy = false;
            IsCornBuy = true;
            IsSlowBuy = false;
            IsPoisonBuy = false;
            //diamonds = 50;
        }else{
            IsCannonBuy = data.IsCannonBuy;
            IsCornBuy = data.IsCornBuy;
            IsSlowBuy = data.IsSlowBuy;
            IsPoisonBuy = data.IsPoisonBuy;
            //diamonds = data.diamonds;
        }
        cornFort.SetActive(!IsCornBuy);
        cannonFort.SetActive(!IsCannonBuy);
        slowFort.SetActive(!IsSlowBuy);
        poisonFort.SetActive(!IsPoisonBuy);

    }
    public void onBtnBackClick(){
        levelFader.FadeToScene("MainMenu");
        SaveSystem.SaveShop();
        SaveSystem.SaveDiamonds();
    }
    public void CornTurretBuy(){
        if(diamonds < 50){
            Debug.Log("Khong du kim cuong de mo khoa");
        }else{
            IsCornBuy = true;
            diamonds -= 50;
            Debug.Log("Da mo khoa thanh cong");
            cornFort.SetActive(!IsCornBuy);  
        }
        
    }
    public void CannonTurretBuy(){
        if(diamonds < 50){
            Debug.Log("Khong du kim cuong de mo khoa");
        }else{
            IsCannonBuy = true;
            diamonds -= 50;
            Debug.Log("Da mo khoa thanh cong");
            cannonFort.SetActive(!IsCannonBuy);    
        }
    }
    public void SlowTurretBuy(){
        if(diamonds < 50){
            Debug.Log("Khong du kim cuong de mo khoa");
        }else{
            IsSlowBuy = true;
            diamonds -= 50;
            Debug.Log("Da mo khoa thanh cong");
            slowFort.SetActive(!IsSlowBuy);
        }
        
    }
    public void PoisonTurretBuy(){
        if(diamonds < 50){
            Debug.Log("Khong du kim cuong de mo khoa");
        }else{
            IsPoisonBuy = true;
            diamonds -= 50;
            Debug.Log("Da mo khoa thanh cong");
            poisonFort.SetActive(!IsPoisonBuy);
        }
        
    }

}
