using UnityEngine;

public class Building : MonoBehaviour
{
    public static Building instance;
    void Awake(){
        if(instance != null){
            Debug.Log("More than one Building in block");
            return;
        }
        instance = this;
    }

    
    public GameObject OnBuildEffect;
    private TurretManagement turretOnBuild;
    private NodeManager onClickNode;
    public bool checkBlock{ get { return turretOnBuild != null; } }
    public bool checkCurrency{ get { return PlayerController.currency >= turretOnBuild.turretCost; } }

    public UpgradeMenuController upgradeMenuController;
    
    public void SelectedNode(NodeManager node){

        if (onClickNode == node){
            undoSelectedNode();
            return;
        }

        onClickNode = node;
        turretOnBuild = null;

        upgradeMenuController.setUI(node);
    }

    public void undoSelectedNode(){
        onClickNode = null;
        upgradeMenuController.hideUI();
    }

    public void BuildTurretSelected(TurretManagement turretInfo){
        turretOnBuild = turretInfo;
        undoSelectedNode();
    }

    public TurretManagement TurretWantToBuild(){
        return turretOnBuild;
    }
}
