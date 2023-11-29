using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : AbstractAI
{

    private GameObject playerBase;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        target = GameObject.FindGameObjectWithTag("PlayerBase").GetComponent<Transform>();
        TargetedType = "Ally";
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (other.tag == "Player")
        {
            targetsReachable.Add(other.gameObject);
        }
    }
    protected override void OnTriggerExit2D(Collider2D other)
    {
        base.OnTriggerExit2D(other);
        if (other.tag == "Player")
        {
            targetsReachable.Remove(other.gameObject);
        }
    }

}
