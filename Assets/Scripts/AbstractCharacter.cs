using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public enum CardinalDirections { CARDINAL_S, CARDINAL_N, CARDINAL_W, CARDINAL_E };
public class AbstractCharacter : MonoBehaviour
{

    private CardinalDirections m_direction; // Current facing direction of the player

    [Header("Stats")]
    [SerializeField] protected float lives;
    [SerializeField] protected int damage;
    [SerializeField] protected float attackSpeed;
    [SerializeField] protected float maxLives;
    [SerializeField] protected float m_speed = 1f; // Speed of the player when he moves
    [SerializeField] protected Image m_lifeBar;

    [Header("Rendu")]
    public Sprite m_frontSprite = null;
    public Sprite m_leftSprite = null;
    public Sprite m_rightSprite = null;
    public Sprite m_backSprite = null;
    protected SpriteRenderer m_renderer;

    protected Rigidbody2D m_rb2D;

    protected float timer = 0f;

    [Header("Audio")]
    [SerializeField] protected AudioManager m_audioManager;
    [SerializeField] protected GameManager m_gameManager;
    [SerializeField] protected WaveManager m_waveManager;

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

    public float Getlives()
    {
        return lives;
    }
    public void Setlives(float newLives)
    {
        lives = newLives;
    }

    public float GetMaxlives()
    {
        return maxLives;
    }
    public void SetMaxlives(float newMaxLives)
    {
        maxLives = newMaxLives;
    }

    public void SetLivesToMaximum()
    {
        lives = maxLives;
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
        if (gameObject.GetComponent<AudioManager>() != null)
        {
            m_audioManager = gameObject.GetComponent<AudioManager>();
        }
        if (FindObjectOfType<GameManager>() != null)
        {
            m_gameManager = FindObjectOfType<GameManager>();
        }
        if (FindObjectOfType<WaveManager>() != null)
        {
            m_waveManager = FindObjectOfType<WaveManager>();
        }
    }

    protected virtual void Update()
    {
        timer += Time.deltaTime;
        m_lifeBar.fillAmount = lives / maxLives;


    }

    protected virtual void ChangeSpriteToMatchDirection(Vector2 force = default(Vector2))
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

    public virtual void IsDamaged(int damage)
    {
        lives -= damage;

        if (lives < 1)
        {
            isDead();
        }
    }

    public virtual void isDead()
    {
        Destroy(gameObject);


    }
    protected void RegenerateAllyLive()
    {
        if (m_gameManager.GetEnemiesAlive())
            SetLivesToMaximum();
    }
}

    /*public virtual void PositionRegardingPlayer()
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
}*/


