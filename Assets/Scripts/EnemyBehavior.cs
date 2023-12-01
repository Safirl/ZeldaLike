using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : AbstractAI
{

    private GameObject playerBase;
    // Start is called before the first frame update
    protected override void Start()
    {
        TargetedType = "Ally";
        base.Start();
    }

    public override void ChoseTargetToAttack()
    {
        base.ChoseTargetToAttack();
        if (targetsReachable.Count == 0 && GameObject.FindGameObjectWithTag("PlayerBase") != null)
        {
            target = GameObject.FindGameObjectWithTag("PlayerBase").GetComponent<Transform>();
            float distance = Vector2.Distance(transform.position, target.transform.position);

            if (distance < 50f )
            {
                Attack();
            }
        }
        
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (other.tag == "Player")
        {
            targetsReachable.Add(other.gameObject);
        }
        if (other.tag == "PlayerBase")
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
        if (other.tag == "PlayerBase")
        {
            targetsReachable.Remove(other.gameObject);
        }
    }

}
