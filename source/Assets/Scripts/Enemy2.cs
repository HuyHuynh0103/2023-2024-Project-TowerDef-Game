using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy2 : MonoBehaviour
{
    Animator animator;
    private bool attacking = false;
    public float speed = 20f;
    private float oldSpeed ;
    public static float timeSlow = 0f;
    private int timePoison = 0;
    private float damagePoison = 0f;
    private Transform target;
    private int waypointIndex = 0;
    public float health = 100f;
    private float oldHealth;
    public int coinsGain = 50;
    public GameObject dieEffect;
    public GameObject dieAudio;
    private bool isDead = false;
    public Image HPBar;

    private void Start() {
        target = Waypoints2.waypoints2[0];
        oldHealth = health;
        oldSpeed = speed;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float amount){
        health -= amount;
        HPBar.fillAmount = health/oldHealth;

        if(health <= 0){
            Die();
        }
    }

    public void TakePoisonEfect(float amount, int time){
        timePoison += time;
        damagePoison = amount;
        StartCoroutine(TakePoisonDamage());
    }
    IEnumerator TakePoisonDamage(){
        while (timePoison>0)
        {
            health = health - oldHealth*damagePoison;
            HPBar.fillAmount = health/oldHealth;
            if(health <= 0){
                Die();
                yield break;
            }
            
            yield return new WaitForSeconds(1f);
            timePoison-=1;
        }
    }
    void Die(){
        gameObject.tag = "Untagged";
        if(!isDead){
            gameObject.tag = "Untagged";
            GameObject effect = (GameObject) Instantiate(dieEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
            PlayerController.currency += coinsGain;
            waveCreator.enemiesStillLive--;
            
        }
        
        isDead = true;

        GameObject dieAudioEffect = (GameObject) Instantiate(dieAudio, transform.position, transform.rotation);
        Destroy(dieAudioEffect, 5f);

        animator.SetBool("Die",true);
        Destroy(gameObject, 5f);
        
        
        Debug.Log("enemy left: "+ waveCreator.enemiesStillLive);
    }
    public void TakeSlow(float speedSlow){
        speed = speedSlow;
    }
    public void TakeBackSpeed(){
        speed = oldSpeed;
    }
    private void Update() {
        if(health>0 && attacking == false){

            Vector3 direction = target.position - transform.position;
            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
            transform.LookAt(target);
        }
        
        //Kiểm tra nhân vật đã đến waypoint chưa
        if(Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWayPoint();
        }

        //Nếu nhân vật bị đóng băng và xét thời gian đóng băng hết hiệu lực
        if(speed <= oldSpeed){
            if(timeSlow <= 0){
                TakeBackSpeed();
                
            }
            timeSlow -= Time.deltaTime;
        }
    }

    void GetNextWayPoint() {
        if(waypointIndex >= Waypoints2.waypoints2.Length - 1){
            
            attacking = true;
            EnemyAttack();
            return;
        }
        waypointIndex++;
        target = Waypoints2.waypoints2[waypointIndex];
    }

    void EnemyAttack() {
        animator.SetBool("IsAttacking", attacking);
    }

}
