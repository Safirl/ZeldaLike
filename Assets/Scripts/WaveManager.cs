using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private Wave2 currentWave;
    public Gamev2Manager gamev2Manager;


    //--------------------------------------//
    //---------------Méthodes---------------//
    //--------------------------------------//

    void Start(){}

    void Update()
    {
        if (gamev2Manager.GetCurrentWave() == 0)
            currentWave = gamev2Manager.levels[gamev2Manager.GetCurrentLevel() - 1].waves[gamev2Manager.GetCurrentWave()];
        else
            currentWave = gamev2Manager.levels[gamev2Manager.GetCurrentLevel() - 1].waves[gamev2Manager.GetCurrentWave() - 1];

        SpawnEnemies();
    }

    //private void LaunchWave()
    //{
    //    if (Input.GetKey(KeyCode.F) && gamev2Manager.GetEnemiesAlive())
    //    {
    //        gamev2Manager.SetCanWin(false);
    //        gamev2Manager.IncrementsCurrentWave();

    //        gamev2Manager.SetCanWin(true);
    //    }
    //}

    private void SpawnEnemies()
    {
        if (Input.GetKey(KeyCode.F) && gamev2Manager.GetEnemiesAlive())
        {
            gamev2Manager.SetCanWin(false);
            gamev2Manager.IncrementsCurrentWave();

            for (int i = 1; i <= currentWave.TypeOfEnemyToSpawn[0].EnemyCount; i++)
            {
                SpawnEnemy(currentWave.TypeOfEnemyToSpawn[0].typeOfEnemies);
            }

            gamev2Manager.SetCanWin(true);
        }
    }


    //ICI: c'est le tuto
    private void SpawnEnemy(GameObject typeOfEnemy)
    {
        Transform randomPoint = gamev2Manager.spawnPoints[Random.Range(0, gamev2Manager.spawnPoints.Length)];
        Instantiate(typeOfEnemy, randomPoint.position, Quaternion.identity);
    }
}
