using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwordBehavior : MonoBehaviour
{
    [SerializeField] private EnemyBehavior m_parent;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (m_parent.GetTarget() == collision.transform)
            {
                PlayerBehavior player = collision.GetComponent<PlayerBehavior>();
                player.IsDamaged(m_parent.GetDamage());
            }
        }
        if (collision.tag == "Ally")
        {
            if (m_parent.GetTarget() == collision.transform) 
            {
                AllyBehavior ally = collision.GetComponent<AllyBehavior>();
                ally.IsDamaged(m_parent.GetDamage());
            }
        }
        if (collision.tag == "PlayerBase")
        {
            if (m_parent.GetTarget() == collision.transform)
            {
                BaseBehavior PlayerBase = collision.GetComponent<BaseBehavior>();
                PlayerBase.IsDamaged(m_parent.GetDamage());
            }
        }
    }
}
