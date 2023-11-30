using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TypeOfEnemyToSpawn
{
    public string typeOfEnemiesName;
    public int EnemyCount;
    public GameObject typeOfEnemies;
}

[System.Serializable]
public class Wave2
{
    public string waveName;
    public TypeOfEnemyToSpawn[] TypeOfEnemyToSpawn;
}

[System.Serializable]
public class Level
{
    public string levelName;
    public Wave2[] waves;
}

public class Gamev2Manager : MonoBehaviour
{
    public Level[] levels;
    public Transform[] spawnPoints;
    private int numberEnemiesAlive = 0;
    private bool enemiesAlive;
    private int currentLevel = 1;
    private int currentWave = 0;
    private bool canWin = false;


    //-------------------------------------------//
    //---------------Getter/Setter---------------//
    //-------------------------------------------//
    public bool GetEnemiesAlive()
    {
        if (GetNumberEnemiesAlive() <= 0)
        {
            enemiesAlive = true;
        }
        else
        {
            enemiesAlive = false;
        }
        return enemiesAlive;
    }

    public int GetNumberEnemiesAlive()
    {
        numberEnemiesAlive = GameObject.FindGameObjectsWithTag("EnemyWave").Length;
        return numberEnemiesAlive;
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }
    public void SetCurrentLevel(int newCurrentLevel)
    {
        currentLevel = newCurrentLevel;
    }

    public int GetCurrentWave()
    {
        return currentWave;
    }
    public void SetCurrentWave(int newCurrentWave)
    {
        currentWave = newCurrentWave;
    }
    public void IncrementsCurrentWave()
    {
        currentWave++;
    }

    public bool GetCanWin()
    {
        return canWin;
    }
    public void SetCanWin(bool newBool)
    {
        canWin = newBool;
    }


    //--------------------------------------//
    //---------------M�thodes---------------//
    //--------------------------------------//

    void Start(){}

    void Update()
    {
        LevelWinCondition();
    }

    public void LevelWinCondition()
    {
        // Refacto: code pas dynamique
        if (currentLevel == 1 && canWin && currentWave == levels[0].waves.Length && GetEnemiesAlive())
        {
            Debug.Log("GAGNER!");

            currentWave = 0;
            currentLevel = 2;
        }
    }


}
