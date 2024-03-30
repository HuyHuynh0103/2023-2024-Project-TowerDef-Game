using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenuController : MonoBehaviour
{

    private NodeManager clickedNode;
    public GameObject menuUI;

    public void setUI(NodeManager clickedNode){

        
        this.clickedNode = clickedNode;

        transform.position = this.clickedNode.NodePosition();

        menuUI.SetActive(true);


    }

    public void hideUI() {
        menuUI.SetActive(false);

    }

    public void LevelUp(){
        clickedNode.LevelUpTurret();
        hideUI();
    }

    public void SellTurret(){
        clickedNode.SellCurrentTurret();
        hideUI();
    }
}
