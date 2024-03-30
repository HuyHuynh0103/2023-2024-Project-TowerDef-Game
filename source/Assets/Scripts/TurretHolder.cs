using UnityEngine;

public class TurretHolder : MonoBehaviour
{
    public TurretManagement cannonFort;
    public TurretManagement cornFort;
    public TurretManagement slowFort;
    public TurretManagement poisonFort;
    Building building;
    void Start() {
        building = Building.instance;
    }
    public void CannonTurretOnSelect() {
        Debug.Log("click on cannon");
        building.BuildTurretSelected(cannonFort);
    }
    public void CornTurretOnSelect(){
        Debug.Log("click on corn");
        building.BuildTurretSelected(cornFort);
    }
    public void SlowGunOnSelect(){
        Debug.Log("click on slow");
        building.BuildTurretSelected(slowFort);
    }
    public void PoisonTurretOnSelect(){
        Debug.Log("click on poison");
        building.BuildTurretSelected(poisonFort);
    }
    
}
