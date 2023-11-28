using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public class SwordBehavior : MonoBehaviour
{
    public PlayerBehavior m_player;
    public EnemyBehavior enemyBehavior;

    [SerializeField] private Rigidbody2D m_rb2D;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.GetComponent<Rigidbody2D>() != null)
        {
            m_rb2D = gameObject.GetComponent<Rigidbody2D>();
        }
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
    public void SetSwordPosition(Transform transformPlayer, CardinalDirections direction)
    {

        float offSet = 10f;
        if(direction == CardinalDirections.CARDINAL_N)
        {
            m_rb2D.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
            m_rb2D.transform.position = new Vector3(transformPlayer.position.x, transformPlayer.position.y + offSet, transformPlayer.position.z);
        }
        if (direction == CardinalDirections.CARDINAL_S)
        {
            m_rb2D.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            m_rb2D.transform.position = new Vector3(transformPlayer.position.x, transformPlayer.position.y - offSet, transformPlayer.position.z);

        }
        if (direction == CardinalDirections.CARDINAL_E)
        {
            m_rb2D.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            m_rb2D.transform.position = new Vector3(transformPlayer.position.x + offSet, transformPlayer.position.y, transformPlayer.position.z);

        }
        if (direction == CardinalDirections.CARDINAL_W)
        {
            m_rb2D.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
            m_rb2D.transform.position = new Vector3(transformPlayer.position.x - offSet, transformPlayer.position.y, transformPlayer.position.z);

        }
    }
}
