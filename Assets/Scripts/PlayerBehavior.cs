/* Author : Raphaël Marczak - 2018/2020, for MIAMI Teaching (IUT Tarbes) and MMI Teaching (IUT Bordeaux Montaigne)
 * 
 * This work is licensed under the CC0 License. 
 * Reworked by Loic et Matthieu
 */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerBehavior : AbstractCharacter
{
    public GameObject m_map = null;
    public GameObject m_base = null;
    public DropdownAllyCount dropdownAllyCount;
    public DialogManager m_dialogDisplayer;
    private GameObject lastEnnemyTouched = null;
    [SerializeField] private GameObject SwordPivot = null;
    [SerializeField] private GameObject Sword = null;
    private GameObject PlayerBase;
    private float countdown = 0f;
    private bool attacking;
    private float cooldown = 0f;
    [SerializeField] private float respawnTime = 3f;
    [SerializeField] private CircleCollider2D ControlAlliesCollider;
    [SerializeField] private List<GameObject> alliesControlled;
    private bool isWriting = false;
    [SerializeField] private AudioManager m_audioManager;

    [SerializeField] GameManager m_gameManager;

    public float regeneration = 3f;

    //Get/SetManager--------------------------------

    public float GetRespawnTime()
    {
        return respawnTime;
    }
    public void SetRespawnTime(float newRespawnTime)
    {
        respawnTime = newRespawnTime;
    }

    public void SetIsWriting(bool newBool)
    {
        isWriting = newBool;
    }
    public bool GetIsWriting()
    {
        return isWriting;
    }


    //Get/SetManager--------------------------------


    private MerchantBehavior merchantBehavior;
    private Dialog m_closestNPCDialog;

    protected override void Awake()
    {
        base.Awake();
        m_closestNPCDialog = null;
        //m_audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // This update is called at a very precise and constant FPS, and
    // must be used for physics modification
    // (i.e. anything related with a RigidBody)
    void FixedUpdate()
    {
        Regeneration();
        // If a dialog is on screen, the player should not be updated
        // If the map is displayed, the player should not be updated
        if (m_dialogDisplayer.IsOnScreen() || m_map.activeSelf)
        {
            return;
        }
        // Moves the player regarding the inputs
        Move();
    }

    protected void Move()
    {
        float horizontalOffset = Input.GetAxis("Horizontal");
        float verticalOffset = Input.GetAxis("Vertical");

        // Translates the player to a new position, at a given speed.
        Vector2 newPos = new Vector2(transform.position.x + horizontalOffset * m_speed,
                                     transform.position.y + verticalOffset * m_speed);
        m_rb2D.MovePosition(newPos);
        //m_audioManager.PlaySound(m_audioManager.walk);

        // Computes the player main direction (North, Sound, East, West)
        if (Mathf.Abs(horizontalOffset) > Mathf.Abs(verticalOffset))
        {
            if (horizontalOffset > 0)
            {
                SetDirection(CardinalDirections.CARDINAL_E);
            }
            else
            {
                SetDirection(CardinalDirections.CARDINAL_W);
            }
        }
        else if (Mathf.Abs(horizontalOffset) < Mathf.Abs(verticalOffset))
        {
            if (verticalOffset > 0)
            {
                SetDirection(CardinalDirections.CARDINAL_N);
            }
            else
            {
                SetDirection(CardinalDirections.CARDINAL_S);
            }
        }
    }


    // This update is called at the FPS which can be fluctuating
    // and should be called for any regular actions not based on
    // physics (i.e. everything not related to RigidBody)
    protected override void Update()
    {
        base.Update();
        cooldown += Time.deltaTime;
        respawnTime -= Time.deltaTime;


        if (!isWriting)
        {
            // If the player presses M, the map will be activated if not on screen
            // or desactivated if already on screen
            if (Input.GetKeyDown(KeyCode.M))
            {
                dropdownAllyCount.UpdateDropdownOptions();
                dropdownAllyCount.UpdateDropdownOptions();
                m_map.SetActive(!m_map.activeSelf);
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                ControlAllies(true);
            }

            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                ControlAllies(false);
            }
        }

        // If a dialog is on screen, the player should not be updated
        // If the map is displayed, the player should not be updated
        if (m_dialogDisplayer.IsOnScreen() || m_map.activeSelf)
        {
            return;
        }

        ChangeSpriteToMatchDirection();

        // If the player presses SPACE, then two solution
        // - If there is a dialog ready to be displayed (i.e. the player is closed to a NPC)
        //   then a dialog is set to the dialogManager
        // - If not, then the player will shoot a fireball
        if (Input.GetKeyDown(KeyCode.Space) && !isWriting)
        {
            if (m_closestNPCDialog != null)
            {
                m_dialogDisplayer.SetDialog(m_closestNPCDialog.GetDialog());
            }
            else if (merchantBehavior != null)
            {
                merchantBehavior.SellSoldiers();
            }

            else if (cooldown >= 0.5f)
            {
                Attack();
                attacking = true;
                cooldown = 0f;
            }
        }
        if (timer - countdown >= 0.2 && attacking == true)
        {
            Sword.SetActive(false);
            attacking = false;
        }
    }
    public void SpawnBase(Transform PlayerTransform)
    {
        transform.position = PlayerTransform.position;
    }

    public void Attack() 
    {
        PivotBehavior Swordpivot = SwordPivot.GetComponent<PivotBehavior>();
        Swordpivot.SetSwordPosition(GetDirection());
        Sword.SetActive(true);
        countdown = timer;
    }


    public override void isDead()
    {
        PlayerBase = GameObject.FindGameObjectWithTag("PlayerBase");
        if (PlayerBase != null)
        {
            gameObject.SetActive(false);
            transform.position = new Vector3 (PlayerBase.transform.position.x, PlayerBase.transform.position.y - 10f, 0);
            m_gameManager.StartRespawnCountDown();
        }
    }

    private void ControlAllies(bool selectAllies)
    {
        if (selectAllies)
        {
            ControlAlliesCollider.enabled = true;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, ControlAlliesCollider.radius);

            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject.layer == 6)
                {
                    alliesControlled.Add(collider.transform.parent.gameObject);
                }
            }
            foreach (GameObject ally in alliesControlled)
            {
                Color newColor;
                if (ColorUtility.TryParseHtmlString("#FFBA6A", out newColor))
                {
                    if (ally.gameObject.tag != "Player")
                    {
                        ally.GetComponent<SpriteRenderer>().color = newColor;
                    }
                }
            }
            ControlAlliesCollider.enabled = false;
        }

        else
        {
            foreach (GameObject ally in alliesControlled)
            {
                Color newColor;
                if (ColorUtility.TryParseHtmlString("#FFFFFF", out newColor))
                {
                    if (ally != null)
                    {
                        ally.gameObject.transform.position = transform.position;
                        ally.GetComponent<SpriteRenderer>().color = newColor;
                    }
                }
            }
            alliesControlled.Clear();
        }

    }

    public override void IsDamaged(int damage)
    {
        base.IsDamaged(damage);
        m_audioManager.PlaySound(m_audioManager.m_clip2, 0.2f);
    }

    // This is automatically called by Unity when the gameObject (here the player)
    // enters a trigger zone. Here, two solutions
    // - the player is in an NPC zone, then he grabs the dialog information ready to be
    //   displayed when SPACE will be pressed
    // - the player is in an instantDialog zone, then he grabs the dialog information and
    //   displays it instantaneously


    public void Regeneration()
    {
        if (lives < maxLives)
        {
            lives += regeneration * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "NPC")
        {
            m_closestNPCDialog = collision.GetComponent<Dialog>();
        }
        else if (collision.tag == "InstantDialog")
        {
            Dialog instantDialog = collision.GetComponent<Dialog>();
            if (instantDialog != null)
            {
                m_dialogDisplayer.SetDialog(instantDialog.GetDialog());
            }
        }
        else if (collision.tag == "Ennemy")
        {
            lastEnnemyTouched = collision.gameObject;
            Debug.Log(lastEnnemyTouched.name.ToString());
        }
        else if (collision.tag == "Merchant")
        {
            merchantBehavior = collision.GetComponent<MerchantBehavior>();
        }
    }

    // This is automatically called by Unity when the gameObject (here the player)
    // leaves a trigger zone. Here, two solutions
    // - the player was in an NPC zone, then the dialog information is removed
    // - the player was in an instantDialog zone, then the instantDialog is destroyed
    //   (as it has been displayed, and must only be displayed once)
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "NPC")
        {
            m_closestNPCDialog = null;
        }
        else if (collision.tag == "InstantDialog")
        {
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "Ennemy")
        {
            Debug.Log(lastEnnemyTouched.name.ToString() + " is not selected");
            lastEnnemyTouched = null;
        }
        else if (collision.tag == "Merchant")
        {
            merchantBehavior = null;
        }
    }
}
