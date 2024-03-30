using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class MenuController : MonoBehaviour
{
    public string LoadedScene = "LevelMenu";
    public string ShopScene = "ShopMenu";
    public string SettingsScene = "SettingsMenu";
    public SceneFader levelFader;
    public TMP_Text start;

    public void Start(){
        PlayerData data = SaveSystem.LoadPlayer();
        if(data == null){
            start.SetText("START");
        }
        else{
            start.SetText("LOAD GAME");
        }
    }
    public void onBtnStartClick(){
        levelFader.FadeToScene(LoadedScene);
    }

    public void onBtnShopClick(){
        levelFader.FadeToScene(ShopScene);
        Debug.Log("Shop");
    }

    public void onBtnQuitClick(){
        Debug.Log("Quit");
        Application.Quit();
    }

    public void onBtnSettingClick(){
        Debug.Log("Settings");
        levelFader.FadeToScene(SettingsScene);
    }
    
}
