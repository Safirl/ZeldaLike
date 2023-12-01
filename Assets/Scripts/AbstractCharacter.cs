using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public enum CardinalDirections { CARDINAL_S, CARDINAL_N, CARDINAL_W, CARDINAL_E };
public class AbstractCharacter : MonoBehaviour
{

    private CardinalDirections m_direction; // Current facing direction of the player
    [SerializeField] protected int lives;
    [SerializeField] protected int damage;
    [SerializeField] protected float attackSpeed;
    [SerializeField] protected float m_speed = 1f; // Speed of the player when he moves


    public Sprite m_frontSprite = null;
    public Sprite m_leftSprite = null;
    public Sprite m_rightSprite = null;
    public Sprite m_backSprite = null;

    protected Rigidbody2D m_rb2D;
    protected SpriteRenderer m_renderer;

    protected float timer = 0f;

    //Get/SetManager--------------------------------
    public CardinalDirections GetDirection()
    {
        return m_direction;
    }
    public void SetDirection(CardinalDirections newDirection)
    {
        m_direction = newDirection;
    }

    public int GetDamage()
    {
        return damage;
    }
    public void SetDamage(int newDamage)
    {
        damage = newDamage;
    }

    //----------------------------------------------

    // Start is called before the first frame update
    protected virtual void Awake()
    {
        if (gameObject.GetComponent<Rigidbody2D>() != null)
        {
            m_rb2D = gameObject.GetComponent<Rigidbody2D>();
        }
        if (gameObject.GetComponent<SpriteRenderer>() != null)
        {
            m_renderer = gameObject.GetComponent<SpriteRenderer>();
        }
    }

    protected virtual void Update()
    {
        timer += Time.deltaTime;
        PositionRegardingPlayer();
    }

    protected void ChangeSpriteToMatchDirection()
    {
        if (m_direction == CardinalDirections.CARDINAL_N)
        {
            m_renderer.sprite = m_backSprite;
        }
        else if (m_direction == CardinalDirections.CARDINAL_S)
        {
            m_renderer.sprite = m_frontSprite;
        }
        else if (m_direction == CardinalDirections.CARDINAL_E)
        {
            m_renderer.sprite = m_rightSprite;
        }
        else if (m_direction == CardinalDirections.CARDINAL_W)
        {
            m_renderer.sprite = m_leftSprite;
        }
    }

    public void IsDamaged(int damage)
    {
        lives -= damage;

        if (lives < 1)
        {
            isDead();
            //todo
            //envoie fonction isDead(this)
            //this == base --> Fin du jeu.
        }
    }

    public virtual void isDead()
    {
        Destroy(gameObject);


    }

    public virtual void PositionRegardingPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            SpriteRenderer playerRenderer = player.GetComponent<SpriteRenderer>();

            if (playerRenderer != null)
            {
                if (this.transform.position.y < player.transform.position.y)
                {
                    m_renderer.sortingOrder = playerRenderer.sortingOrder + 1;
                }
                else
                {
                    m_renderer.sortingOrder = playerRenderer.sortingOrder - 1;
                }
            }
        }
    }
}


