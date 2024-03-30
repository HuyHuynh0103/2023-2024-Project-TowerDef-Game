using System;

using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    
    [Header("Attributes")]
    public float range = 15f;
    public float fireRate;
    private float fireCountdown;
    [Header("Unity Set Up Fields")]
    public String eneymyTag = "Enemy";
    public Transform rotatePart;
    public float turnSpeed = 10f;

    public GameObject bulletPrefab; 
    public Transform firePoint;
    public ParticleSystem muzzelFlash;
    public GameObject SoundFireShot;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f,0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null){
            return;
        }
        //Target Lock On
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir); 
        Vector3 rotation = Quaternion.Lerp(rotatePart.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        rotatePart.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if(fireCountdown <= 0){
            Shoot();
            if (!muzzelFlash.isPlaying)
            {
                muzzelFlash.Play();
            }
            fireCountdown = fireRate;
             if (muzzelFlash.isPlaying)
            {
                muzzelFlash.Stop();
            }
        }
        fireCountdown -= Time.deltaTime;
    }

    void Shoot(){
        GameObject fireShot = (GameObject) Instantiate(SoundFireShot, firePoint.position, firePoint.rotation);
        Destroy(fireShot,5f);
        GameObject bulletShoot = (GameObject) Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        BulletController bullet = bulletShoot.GetComponent<BulletController>();

        if(bullet != null){
            bullet.Seek(target);
        }
        
    }

    void UpdateTarget(){
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(eneymyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance){
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range){
            target = nearestEnemy.transform;
        }else{
            target = null;
        }
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
