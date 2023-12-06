using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private PlayerBehavior playerBehavior;
    private Wave currentWave;
    public GameManager gameManager;
    float HoldKeyCountDown = 3f;
    ShowCountDown m_showCountDown;


    public float getHoldKeyCountDown()
    {
        return HoldKeyCountDown;
    }

    //--------------------------------------//
    //---------------Méthodes---------------//
    //--------------------------------------//

    void Start()
    {
        m_showCountDown = FindAnyObjectByType<ShowCountDown>();
    }

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
        if (Input.GetKeyDown(KeyCode.Space))
            HoldKeyCountDown = 3.3f;

        if (Input.GetKey(KeyCode.Space) && gameManager.GetEnemiesAlive() && !playerBehavior.GetIsWriting())
        {
            HoldKeyCountDown -= Time.deltaTime;
            Debug.Log(HoldKeyCountDown);
            if (HoldKeyCountDown < 3f)
            {


                m_showCountDown.ShowWaveCountDown(true);

                if (HoldKeyCountDown <= 0)
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
        }
        else
        {
            m_showCountDown.ShowWaveCountDown(false);
        }
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
