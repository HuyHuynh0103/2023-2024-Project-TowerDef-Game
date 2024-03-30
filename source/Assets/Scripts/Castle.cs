using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    public int GoblinDamage;
    public GameObject GoblinAttackAudio;
    public int HobGoblinDamage;
    public GameObject HobGoblinAttackAudio;
    public int TrollDamage;
    public GameObject TrollAttackAudio;
    public int RedDragonDamage;
    public GameObject RedDragonAttackAudio;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public float RandomDmgTaken(int minDmg, int maxDmg){
        int damageDealt;
        damageDealt = (int)Random.Range(minDmg, maxDmg);
        return damageDealt;
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("GoblinWeapon")){
            TakeGoblinDamage();
            GameObject AudioEffectGoblin = (GameObject) Instantiate(GoblinAttackAudio, transform.position,transform.rotation);
            Destroy(AudioEffectGoblin, 5f);
        }
        if(other.gameObject.CompareTag("HobGoblinWeapon")){
            TakeHobGoblinDamage();
            GameObject AudioEffectHobGoblin = (GameObject) Instantiate(HobGoblinAttackAudio, transform.position,transform.rotation);
            Destroy(AudioEffectHobGoblin, 5f);
        }
        if(other.gameObject.CompareTag("TrollWeapon")){
            TakeTrollDamage();
            GameObject AudioEffectTroll = (GameObject) Instantiate(TrollAttackAudio, transform.position,transform.rotation);
            Destroy(AudioEffectTroll, 5f);
        }
        if(other.gameObject.CompareTag("RedDragonWeapon")){
            TakeRedDragonDamage();
            GameObject AudioEffectRedDragon = (GameObject) Instantiate(RedDragonAttackAudio, transform.position,transform.rotation);
            Destroy(AudioEffectRedDragon, 5f);
        }
    }

    void TakeGoblinDamage(){
        PlayerController.health = (int)(PlayerController.health - RandomDmgTaken(GoblinDamage / 2, GoblinDamage));
    }

    void TakeHobGoblinDamage(){
        PlayerController.health = (int)(PlayerController.health - RandomDmgTaken(HobGoblinDamage / 2, HobGoblinDamage));
    }
    void TakeTrollDamage(){
        PlayerController.health = (int)(PlayerController.health - RandomDmgTaken(TrollDamage / 2, TrollDamage));
    }
    void TakeRedDragonDamage(){
        PlayerController.health = (int)(PlayerController.health - RandomDmgTaken(RedDragonDamage / 2, RedDragonDamage));
    }
}
