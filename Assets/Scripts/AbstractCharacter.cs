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

    //----------------------------------------------

    // Start is called before the first frame update
    protected virtual void Awake()
    {
        m_rb2D = this.gameObject.GetComponent<Rigidbody2D>();
        m_renderer = this.gameObject.GetComponent<SpriteRenderer>();
        Debug.Log(this.gameObject);
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

}

