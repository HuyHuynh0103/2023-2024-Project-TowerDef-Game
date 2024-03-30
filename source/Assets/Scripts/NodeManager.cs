using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;

public class NodeManager : MonoBehaviour
{
    
    public Color hoverColor;
    public Color originColor;
    public Color alertColor;
    private Renderer rend;
    public Vector3 PositionYOffset;

    [HideInInspector]
    public GameObject currentTurret;
    [HideInInspector]
    public TurretManagement turretManagement;
    [HideInInspector]
    public bool isUpgraded = false;
    private int level = 0;

    Building building;
    

    // Start is called before the first frame update
    void Start() {
        rend = GetComponent<Renderer>();
        originColor = rend.material.color;

        building = Building.instance;
    }

    public Vector3 NodePosition(){
        return transform.position + PositionYOffset;
    }

    void BuildTurret(TurretManagement turretModel){
        if (PlayerController.currency < turretModel.turretCost){
            Debug.Log("Ko du tien de mua tru sung");
            return;
        }

        PlayerController.currency = PlayerController.currency - turretModel.turretCost;

        GameObject _turret = (GameObject)Instantiate(turretModel.turretPrefab, NodePosition(), Quaternion.identity);
        currentTurret = _turret;

        turretManagement = turretModel;

        GameObject buildEffect = (GameObject)Instantiate(building.OnBuildEffect, NodePosition(), Quaternion.identity);
        Destroy(buildEffect, 5f);
        level = 1;

        Debug.Log("So tien con lai cua nguoi choi: ");
    }

    public void SellCurrentTurret(){
        Destroy(currentTurret);
        if(level == 1){
            PlayerController.currency += turretManagement.GetSellPrice(0);
        }
        if(level == 2){
            PlayerController.currency += turretManagement.GetSellPrice(turretManagement.turretUpgradeCost);
        }
        if(level == 3){
            PlayerController.currency += turretManagement.GetSellPrice(turretManagement.turretUpgradeCostLv3 + turretManagement.turretCost);
        }
        
    }
    public void LevelUpTurret(){


        if(level == 1){
            if (PlayerController.currency < turretManagement.turretUpgradeCost){
                Debug.Log("Ko du tien de nang tru sung");
                return;
            }
            PlayerController.currency = PlayerController.currency - turretManagement.turretUpgradeCost;
            //Destroy Old Turret
            Destroy(currentTurret);

            //Build new Turret
            GameObject _turret = (GameObject)Instantiate(turretManagement.turretUpgradePrefab, NodePosition(), Quaternion.identity);
            currentTurret = _turret;
             
            

            GameObject buildEffect = (GameObject)Instantiate(building.OnBuildEffect, NodePosition(), Quaternion.identity);
            Destroy(buildEffect, 5f);

            //isUpgraded = true;
            level = 2;

            Debug.Log("Tru da duoc nang cap!");
            return;
        }
        
        if(level == 2){
            if (PlayerController.currency < turretManagement.turretUpgradeCostLv3){
                Debug.Log("Ko du tien de nang tru sung");
                return;
            }
            PlayerController.currency = PlayerController.currency - turretManagement.turretUpgradeCostLv3;
            //Destroy Old Turret
            Destroy(currentTurret);

            //Build new Turret
            GameObject _turret = (GameObject)Instantiate(turretManagement.turretUpgradePrefabLv3, NodePosition(), Quaternion.identity);
            currentTurret = _turret;

            GameObject buildEffect = (GameObject)Instantiate(building.OnBuildEffect, NodePosition(), Quaternion.identity);
            Destroy(buildEffect, 5f);

            isUpgraded = true;

            Debug.Log("Tru da duoc nang cap!");
            level = 3;
            return;
        }
        if(isUpgraded){
            Debug.Log("Tru da dat cap toi da");
            return;
        }

        
    }

    void OnMouseEnter() {
        if (EventSystem.current.IsPointerOverGameObject()){
            return;
        }

        if (!building.checkBlock){
            return;
        }

        if (building.checkCurrency){
            rend.material.color = hoverColor;
        }else 
        {
            rend.material.color = alertColor;
        }
        
        
    }
    void OnMouseExit() {
        rend.material.color = originColor;
    }

    void OnMouseDown(){
        if (EventSystem.current.IsPointerOverGameObject()){
            return;
        }
        
        if (currentTurret != null){
            building.SelectedNode(this);
            Debug.Log("Da co tru o day");
            return;
        }

        if (!building.checkBlock){
            return;
        }

        //building.BuildTurret(this);
        BuildTurret(building.TurretWantToBuild());
    }
}
