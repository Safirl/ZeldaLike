using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private Wave currentWave;
    public GameManager gameManager;


    //--------------------------------------//
    //---------------Méthodes---------------//
    //--------------------------------------//

    void Start(){}

    void Update()
    {
        if (gameManager.GetCurrentWave() == 0)
            currentWave = gameManager.levels[gameManager.GetCurrentLevel() - 1].waves[gameManager.GetCurrentWave()];
        else
            currentWave = gameManager.levels[gameManager.GetCurrentLevel() - 1].waves[gameManager.GetCurrentWave() - 1];

        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        if (Input.GetKey(KeyCode.F) && gameManager.GetEnemiesAlive())
        {
            gameManager.SetCanWin(false);
            gameManager.IncrementsCurrentWave();

            for (int i = 1; i <= currentWave.TypeOfEnemyToSpawn[0].EnemyCount; i++)
            {
                SpawnEnemy(currentWave.TypeOfEnemyToSpawn[0].typeOfEnemies);
            }

            gameManager.SetCanWin(true);
        }
    }

    private void SpawnEnemy(GameObject typeOfEnemy)
    {
        Transform randomPoint = gameManager.spawnPoints[Random.Range(0, gameManager.spawnPoints.Length)];
        Instantiate(typeOfEnemy, randomPoint.position, Quaternion.identity);
    }
}
