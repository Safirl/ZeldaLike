using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void startGame(bool lose)
    {
        if (lose)
            SceneManager.LoadScene("HomeScene");
        else
            SceneManager.LoadScene("BuildMap");

    }
    public void ShowCommands()
    {
        SceneManager.LoadScene("Commandes");
    }

}
