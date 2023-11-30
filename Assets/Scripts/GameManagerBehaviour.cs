using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using UnityEngine;

public class GameManagerBehaviour : MonoBehaviour
{
    private int wave = 0;
    private int level = 1;
    public int arrayEnemy = 0;
    public int enemyCount;
    public int numberAllies;
    public int lives;
    public int baselife;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        WinWaveCondition();
        LoseCondition();
        DistributeEnemies();
    }

    // Méthode pour vérifier la condition de victoire de la vague
    private void WinWaveCondition()
    {
        if (enemyCount == 0 && wave < 3)
        {
            wave = wave + 1;
        }
    }

    private void LoseCondition()
    {
        if (lives == 0)
        {
            wave = 0;
        } else if (baselife == 0){
            wave = 0;
        }
    }

    private void DistributeEnemies()
    {
        if (baselife > 0 && lives > 0)
        {

        }
    }

}