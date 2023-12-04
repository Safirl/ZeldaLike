using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseBehavior : AbstractCharacter
{
    [SerializeField] GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        SetDirection(CardinalDirections.CARDINAL_S);
    }

    // Update is called once per frame
    protected override void  Update()
    {
        base.Update();
        RegenerateAllyLive();
    }

    public override void isDead()
    {
        gameManager.loseLogic();
    }


}
