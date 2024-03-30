using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class waveCreator : MonoBehaviour
{
    //public Transform enemyPrefab;
    public WaveManagement[] waves;
    public WaveManagement[] waves2;
    public Transform createPoint;
    public Transform createPoint2;
    public static int enemiesStillLive = 0;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private int waveIndex = 0;
    public TMP_Text waveCountDownText;
    public GameController gameController;
    public int level;
    public void Start() {
        enemiesStillLive = 0;
        DiamomdsData data = SaveSystem.LoadDiamonds();
        if(data == null){
            ShopMenu.diamonds = 50;
        }else{
            ShopMenu.diamonds = data.diamonds;
        }
 
    }
    private void Update() {
        Debug.Log("Current wave: "+waveIndex);

        if(waveIndex == waves.Length  && enemiesStillLive <=0){
            gameController.LevelWin();
            ShopMenu.diamonds += 50;
            this.enabled = false;
        }
        else {
                countdown-= Time.deltaTime;
                countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
                waveCountDownText.text = string.Format("{0:0}", countdown);
                waveCountDownText.SetText("Next Wave: " + countdown);
            if(countdown <= 0){
                StartCoroutine(CreateWave());
                countdown = timeBetweenWaves;
            }
        }
    }

    IEnumerator CreateWave(){

        WaveManagement wave = waves[waveIndex];
        for (int i = 0; i < wave.enemies.Length; i++)
        {
            CreateEnemy(wave.enemies[i]);
            yield return new WaitForSeconds(wave.rate);
        }
        
        WaveManagement wave2 = waves2[waveIndex];
        for (int i = 0; i < wave2.enemies.Length; i++)
        {
            CreateEnemy2(wave2.enemies[i]);
            yield return new WaitForSeconds(wave2.rate);
        }
        waveIndex++;
        
        int waveIndex1 = waveIndex;
        PlayerController.currentLevel = "";
        PlayerController.currentLevel += "Level " + level + "-" + waveIndex1;
        Debug.Log(PlayerController.currentLevel);
        
    }

  

    void CreateEnemy(GameObject enemy){
        Instantiate(enemy, createPoint.position, createPoint.rotation);
        enemiesStillLive++;
    }

    void CreateEnemy2(GameObject enemy){
        Instantiate(enemy, createPoint2.position, createPoint2.rotation);
        enemiesStillLive++;
    }
}
