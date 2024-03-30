using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelComplete : MonoBehaviour{
    public string menuScene = "MainMenu";
    public string nextLv;
    public int nextHighestLevel;
    public SceneFader sceneFader;
    public void onContinueButton(){
        PlayerPrefs.SetInt("highestLevel",nextHighestLevel);
        sceneFader.FadeToScene(nextLv);
        SaveSystem.SavePlayer(this);
        SaveSystem.SaveDiamonds();
    }
    
    public void RetryButtonClick(){
        sceneFader.FadeToScene(SceneManager.GetActiveScene().name);
    }

    public void onMenuButton(){
        SaveSystem.SavePlayer(this);
        SaveSystem.SaveDiamonds();
        sceneFader.FadeToScene(menuScene);
    }
}
