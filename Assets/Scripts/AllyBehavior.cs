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

/*public override void ChoseTargetToAttack()
{
    base.ChoseTargetToAttack();
    if (targetsReachable.Count == 0 && GameObject.FindGameObjectWithTag("PlayerBase") != null)
        target = GameObject.FindGameObjectWithTag("PlayerBase").GetComponent<Transform>();
}*/

/*protected override void OnTriggerEnter2D(Collider2D other)
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
}*/
}
