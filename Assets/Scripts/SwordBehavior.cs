using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public class SwordBehavior : MonoBehaviour
{
    [SerializeField] private PlayerBehavior m_player;
    [SerializeField] private AllyBehavior m_ally;

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
            if (collision.transform.parent.gameObject.tag == "Enemy")
            {
                if (m_player != null)
                {

                    EnemyBehavior enemy = collision.transform.parent.gameObject.GetComponent<EnemyBehavior>();
                    enemy.IsDamaged(m_player.GetDamage());

                }
                else if (m_ally != null)
                {
                    EnemyBehavior enemy = collision.transform.parent.gameObject.GetComponent<EnemyBehavior>();
                    enemy.IsDamaged(m_ally.GetDamage());
                    
                }

            }
        }
    } 
}
