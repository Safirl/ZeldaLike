using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllySwordBehavior : MonoBehaviour
{
    [SerializeField] private AllyBehavior m_ally;
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
            enemy.IsDamaged(m_ally.GetDamage());
        }
    }
}
