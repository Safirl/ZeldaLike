using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

    public class Wave
    {
        public string waveName;
        public int EnemyCount;
        public GameObject[] typeOfEnemies;
        public float spawnInterval;
    }

public class Spawner : MonoBehaviour
{
    public Wave[] waves;
    public Transform[] spawnPoints;

    private Wave currentWave;
    private int currentWaveNumber = 0;
    private float nextSpawnTime;
    private bool canSpawn = true;
    public int eggs = 0;


    //Init Getter et Setter --------
    public int GetCurrentWaveNumber()
    {
        return currentWaveNumber;
    }
    public void SetCurrentWaveNumber(int newCurrentWaveNumber)
    {
        currentWaveNumber = newCurrentWaveNumber;
    }

    public bool GetcanSpawn()
    {
        return canSpawn;
    }
    public void SetcanSpawn(bool newcanSpawn)
    {
        canSpawn = newcanSpawn;
    }
    //--------------------------------


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(currentWaveNumber);

    }

    // Update is called once per frame
    private void Update()
    {
        currentWave = waves[currentWaveNumber];
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("EnemyWave");
        
        SpawnWave();


        if (totalEnemies.Length == 0 && !canSpawn && currentWaveNumber + 1 != waves.Length)
        {
            currentWaveNumber++;
            Debug.Log("Manche suivante");
            canSpawn = true;
        }

    }



void SpawnWave()
    {
        if (canSpawn && nextSpawnTime < Time.time)
        {
            GameObject randomEnemy = currentWave.typeOfEnemies[Random.Range(0, currentWave.typeOfEnemies.Length)];
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);

            currentWave.EnemyCount--;
            nextSpawnTime = Time.time + currentWave.spawnInterval;
            if (currentWave.EnemyCount == 0)
            {
                canSpawn = false;
                eggs = eggs + 20;
                Debug.Log("le joueur gagne" + eggs);

            }
            GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("EnemyWave");
            Debug.Log("vague numéro :" + currentWaveNumber);
            Debug.Log("nombre d'ennemis" + totalEnemies.Length);


        }

    }

}