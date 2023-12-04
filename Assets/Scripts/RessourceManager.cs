using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UI;

public class RessourceManager : MonoBehaviour
{
    private int coins = 10;
    [SerializeField] private Text text;


    //Getter et Setter ------------------------
    public int GetCoins()
    {
        return coins;
    }
    public void SetCoins(int newCoins)
    {
        coins = newCoins;
    }

    public void AddCoins(int coinsAdded)
    {
        coins += coinsAdded;
    }

    public void SubstractCoins(int coinsAdded)
    {
        coins -= coinsAdded;
    }

    //Getter et Setter ------------------------


    void Start()
    {
        text.text = "Number of eggs : " + coins;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Number of eggs : " + coins;

    }
}
