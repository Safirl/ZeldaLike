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
        if (collision.gameObject.layer == 6)
        {
            if (collision.transform.parent.gameObject.tag == "Player")
            {
                {
                    PlayerBehavior player = collision.transform.parent.gameObject.GetComponent<PlayerBehavior>();
                    player.IsDamaged(m_parent.GetDamage());
                }
            }
            if (collision.transform.parent.gameObject.tag == "Ally")
            {               
                    AllyBehavior ally = collision.transform.parent.gameObject.GetComponent<AllyBehavior>();
                    ally.IsDamaged(m_parent.GetDamage());
            }
            if (collision.transform.parent.gameObject.tag == "PlayerBase")
            {
              
                BaseBehavior PlayerBase = collision.transform.parent.gameObject.GetComponent<BaseBehavior>();
                PlayerBase.IsDamaged(m_parent.GetDamage());
              
            }
        }
    }
}
