using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Wave Wave;
    public Spawner Spawner;
    public int eggs;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("EnemyWave");

        if (Spawner.GetCurrentWaveNumber() == 0 && totalEnemies.Length == 0 && !Spawner.GetcanSpawn())
        {
            eggs = eggs + 10;
            Debug.Log("le joueur gagne" + eggs);
        } 

        if (Spawner.GetCurrentWaveNumber() == 1 && totalEnemies.Length == 0 && !Spawner.GetcanSpawn())
        {
            eggs = eggs + 15;
            Debug.Log("le joueur gagne" + eggs);
        }

        if (Spawner.GetCurrentWaveNumber() == 2 && totalEnemies.Length == 0 && !Spawner.GetcanSpawn())
        {
            eggs = eggs + 20;
            Debug.Log("le joueur gagne" + eggs);

        }
    }

}
