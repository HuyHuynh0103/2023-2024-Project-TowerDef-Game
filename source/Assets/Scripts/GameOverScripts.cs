using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScripts : MonoBehaviour
{
    public SceneFader sceneFader;
    public TMP_Text currentLevelText;
    public string menuScene = "MainMenu";

    void OnEnable(){
        currentLevelText.text = PlayerController.currentLevel;
        Time.timeScale = 0f;
    }

    public void RetryButtonClick(){

        sceneFader.FadeToScene(SceneManager.GetActiveScene().name);
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void MenuButtonClick(){
        Time.timeScale = 1f;
        sceneFader.FadeToScene(menuScene);
    }
}
