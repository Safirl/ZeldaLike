using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private PlayerBehavior playerBehavior;
    private Wave currentWave;
    public GameManager gameManager;
    float HoldKeyCountDown = 3f;


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
        if (Input.GetKeyDown(KeyCode.F))
            HoldKeyCountDown = 3f;

        if (Input.GetKey(KeyCode.F) && gameManager.GetEnemiesAlive() && !playerBehavior.GetIsWriting())
        {
            HoldKeyCountDown -= Time.deltaTime;
            Debug.Log(HoldKeyCountDown);
            // check if the start time plus [holdTime] is more or equal to the current time.
            // If so, we held the button for [holdTime] seconds.
            if (HoldKeyCountDown <= 0)
            {
                
/*        if (Input.GetKey(KeyCode.F) && gameManager.GetEnemiesAlive() && !playerBehavior.GetIsWriting())
        {*/

            gameManager.SetCanWin(false);
            gameManager.IncrementsCurrentWave();

            for (int i = 1; i <= currentWave.TypeOfEnemyToSpawn[0].EnemyCount; i++)
            {
                SpawnEnemy(currentWave.TypeOfEnemyToSpawn[0].typeOfEnemies);
            }

            gameManager.SetCanWin(true);
            }

        }
        //}
    }

    private void SpawnEnemy(GameObject typeOfEnemy)
    {
        Transform randomPoint = gameManager.spawnPoints[Random.Range(0, gameManager.spawnPoints.Length)];
        Instantiate(typeOfEnemy, new Vector3 (randomPoint.position.x, randomPoint.position.y, 0), Quaternion.identity);
    }

    /*private void RegenerateAlliesLives()
    {
        foreach (GameObject ally in GameObject.FindGameObjectsWithTag("Ally"))
        {
            ally.GetComponent<AllyBehavior>().SetLivesToMaximum();
        }
    }*/
}
