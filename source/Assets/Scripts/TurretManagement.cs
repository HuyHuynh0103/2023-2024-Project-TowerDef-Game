using UnityEngine;
[System.Serializable]
public class TurretManagement
{
    public GameObject turretPrefab;
    public int turretCost;

    public GameObject turretUpgradePrefab;
    public int turretUpgradeCost;
    public GameObject turretUpgradePrefabLv3;
    public int turretUpgradeCostLv3;


    public int GetSellPrice(int upgradeCost){
        return (turretCost + upgradeCost) /2;
    }

    
}
