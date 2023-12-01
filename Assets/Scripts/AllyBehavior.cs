using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AllyBehavior : AbstractAI
{

    // Start is called before the first frame update
    protected override void Start()
    {
        TargetedType = "Enemy";
        base.Start();
    }


}
