using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseOptions : MonoBehaviour
{
    public GameObject pauseUI ;
    public SceneFader sceneFader;
    public string menuScene = "MainMenu";

    public bool enablePause = true;
    private void Update() {
        if(Input.GetKeyDown(KeyCode.P)){
            //ChangeState();
            OnPause();
        }
    }


    //Đổi trạng thái giữa pause và conitnue()
    public void OnPause(){
        if(enablePause){
            pauseUI.SetActive(!pauseUI.activeSelf);
            Time.timeScale = 0f;
            enablePause = false;
        }
        
    }

    public void Continue(){
        pauseUI.SetActive(!pauseUI.activeSelf);
        Time.timeScale = 1f;
        enablePause = true;
    }

    
    public void Replay(){
        Time.timeScale = 1f;
        enablePause = true;
        sceneFader.FadeToScene(SceneManager.GetActiveScene().name);
        
        
    }

    public void Menu(){
        Time.timeScale = 1f;
        sceneFader.FadeToScene(menuScene);
    }
}
