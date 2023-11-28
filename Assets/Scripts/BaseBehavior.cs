using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBehavior : AbstractCharacter
{
    // Start is called before the first frame update
    void Start()
    {
        lives = 200;
        SetDirection(CardinalDirections.CARDINAL_S);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
