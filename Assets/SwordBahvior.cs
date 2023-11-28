using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class SwordBahvior : MonoBehaviour
{
    public PlayerBehavior m_player;
    public EnemyBehavior enemyBehavior;
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
        if (collision.tag == "Enemy")
        {
            EnemyBehavior enemyBehavior = collision.GetComponent<EnemyBehavior>();
            enemyBehavior.IsDamaged(m_player.GetDamage());
        }
    }
}
