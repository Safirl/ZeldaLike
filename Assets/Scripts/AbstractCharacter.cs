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
        Debug.Log(lives);

        if(lives < 1)
        {
            Debug.Log("I'm dead");
            //todo
            //envoie fonction isDead(this)
            //this == base --> Fin du jeu.
        }
    }
}

