using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public class SwordBehavior : MonoBehaviour
{
    [SerializeField] private PlayerBehavior m_player;
    /*public AbstractAI enemyBehavior;*/

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
            AbstractAI enemy = collision.GetComponent<AbstractAI>();
            enemy.IsDamaged(m_player.GetDamage());
        }
    } 
}
