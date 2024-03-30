using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static bool gameFinished;

    public GameObject gameOverUI;
    public GameObject levelComplete;

    void Start(){
        gameFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameFinished){
            return;
        }
        if(Input.GetKeyDown("r")){
            FinishGame();
        }
        if(PlayerController.health <= 0){
            FinishGame();
        }
    }

    void FinishGame(){
        gameFinished = true;
        gameOverUI.SetActive(true);
        Debug.Log("Game Over");
    }

    public void LevelWin(){
        gameFinished = true;
        levelComplete.SetActive(true);
        Debug.Log("LEVEL WON");
        
    }

    
}
