using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelController : MonoBehaviour
{
    
    public string menuScene = "MainMenu";
    public SceneFader sceneFader;
    public Button[] Levels;
    int highestLevel;
    public void Start(){
        PlayerData data = SaveSystem.LoadPlayer();
        if(data == null){
            highestLevel = 1;
        }else {
            highestLevel = data.HighestLevel;
        }
        for(int i = 0; i < Levels.Length; i++){
            if(i + 1 > highestLevel){
                Levels[i].interactable = false;
            }
            Debug.Log(Levels[i]);
        }
        
        

    }
    public void onLevelClicked(string levelChose){
        sceneFader.FadeToScene(levelChose);
    }

    public void onBack2MenuClicked(){
        
        sceneFader.FadeToScene(menuScene);
    }
}
