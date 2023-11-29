using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSwordPosition(CardinalDirections direction)
    {
        if (direction == CardinalDirections.CARDINAL_N)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 180f);
        }
        if (direction == CardinalDirections.CARDINAL_S)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);  

        }
        if (direction == CardinalDirections.CARDINAL_E)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 90f);

        }
        if (direction == CardinalDirections.CARDINAL_W)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -90f);

        }
    }
}
