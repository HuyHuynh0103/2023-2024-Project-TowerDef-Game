using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    
 
    public float minDmg;
    public float maxDmg;
    public GameObject impactEffect;
    public GameObject hitEffectAudio;
    public float explosionRange = 0f;
    public float timeSlowEffect = 0f;
    public int timePoisonEffect = 0;
    public bool isSlow = false;
    public bool isPoison = false;

    public void Seek(Transform _target){
        target = _target;
    }

    
    public float RandomDmg(){
        float damageDealt;
        damageDealt = Random.Range(minDmg, maxDmg);
        return damageDealt;
    }
    // Update is called once per frame
    void Update()
    {
        if(target == null){
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame){
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);

    }

    void HitTarget(){
        GameObject effectIns = (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);
        if(explosionRange > 0f && isPoison == false){
            Explode();
        }else if(explosionRange > 0f && isPoison == true){
            ExplodePoison();
        }else if(isSlow && effectIns != null){
            SlowEnemy(target);
        }else{
            Damage(target);
        }
        
        Destroy(gameObject);
        GameObject effectAudio = (GameObject) Instantiate(hitEffectAudio, transform.position, transform.rotation);
        Destroy(effectAudio, 5f);
    }

    void Explode(){
       Collider[] explodeObjects = Physics.OverlapSphere(transform.position, explosionRange);
       foreach (Collider collider in explodeObjects)
       {
        if(collider.tag == "Enemy"){
            Damage(collider.transform);
        }
       }
    }

    void Damage(Transform enemy){
        Enemy e = enemy.GetComponent<Enemy>();
        
        if(e != null){
            e.TakeDamage(RandomDmg());
        }
        Enemy2 e2 = enemy.GetComponent<Enemy2>();
        if(e2 != null){
            e2.TakeDamage(RandomDmg());
        }
        
    }
     void SlowEnemy(Transform enemy){
        Enemy e = enemy.GetComponent<Enemy>();
         if(e != null){
           e.TakeSlow(5f);
           Enemy.timeSlow = timeSlowEffect;
        }
        Enemy2 e2 = enemy.GetComponent<Enemy2>();
        if(e2 != null){
            e2.TakeSlow(5f);
            Enemy2.timeSlow = timeSlowEffect;
        }
    }

    void ExplodePoison(){
        Collider[] explodedPoisonObjects = Physics.OverlapSphere(transform.position, explosionRange);
        foreach (Collider item in explodedPoisonObjects)
        {
            if(item.tag == "Enemy"){
                PoisonEnemy(item.transform);
            }
        }
    }

    void PoisonEnemy(Transform enemy){
        Enemy e = enemy.GetComponent<Enemy>();
        if(e != null){
            e.TakePoisonEfect(RandomDmg(),timePoisonEffect);
        }
        Enemy2 e2 = enemy.GetComponent<Enemy2>();
        if(e2 != null){
            e2.TakePoisonEfect(RandomDmg(),timePoisonEffect);
        }
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRange);    
    }
}
