using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public int HighestLevel;
    
    public PlayerData(LevelComplete levelComplete){
        HighestLevel = levelComplete.nextHighestLevel;
    }
}
