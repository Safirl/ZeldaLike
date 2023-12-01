using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class AbstractAI : AbstractCharacter
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float nextWayPointDistance = 3f;
    [SerializeField] protected GameObject Sword = null;

    protected Path path;
    protected int currentWayPoint = 0;
    protected bool reachedEndOfPath = false;

    protected Seeker seeker;
    protected string TargetedType;
    [SerializeField] protected List<GameObject> targetsReachable;
    protected float cooldown = 0f;
    protected float countdown = 0f;

    //Getter---------------------------
    public Transform GetTarget()
    {
        return target;
    }
    /*public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }*/

    //Getter---------------------------


    // Start is called before the first frame update
    protected virtual void Start()
    {
        seeker = GetComponent<Seeker>();

        InvokeRepeating("UpdatePath", 0f, 0.5f);
        InvokeRepeating("ChoseTargetToAttack", 0f, 0.5f);
    }
    public virtual void ChoseTargetToAttack()
    {
            if (targetsReachable.Count > 0) { 
                float closestDistance = 100000f;
                foreach (GameObject targetReachable in targetsReachable)
                {
                    if (targetReachable != null)
                    {
                        float distance = Vector2.Distance(transform.position, targetReachable.transform.position);

                        if (distance < closestDistance)
                        {
                            closestDistance = distance;
                            if (targetReachable != null)
                                target = targetReachable.transform;
    
                        }
                    }
                    else
                    {
                        targetsReachable.Remove(targetReachable);
                        break;
                    }
                    if (closestDistance < 40f)
                    {
                        Attack();
                    }
                }
            }
    }

    public void Attack()
    {
        if (cooldown >= 0.8f)
        {
            cooldown = 0f;
            Sword.SetActive(true);
            countdown = timer;
        }
    }

    public void UpdatePath()
    {
        if (seeker != null && target != null)
        {
            if (seeker.IsDone())
            {
                seeker.StartPath(m_rb2D.position, target.position, OnPathComplete);
            }
        }
    }

    public void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }

    protected override void Update()
    {
        base.Update();
        cooldown += Time.deltaTime;

        if(timer - countdown >= 0.2)
        {
            Sword.SetActive(false);
        }

    }

    // Update is called once per frame
    protected void FixedUpdate()
    {
        if (path == null)
            return;
        if (currentWayPoint >= path.vectorPath.Count)
        {
            reachedEndOfPath=true;
            return;
        }else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2) path.vectorPath[currentWayPoint] - m_rb2D.position).normalized;
        Vector2 force = direction * m_speed * Time.deltaTime;

        m_rb2D.AddForce(force);

        float distance = Vector2.Distance(m_rb2D.position, path.vectorPath[currentWayPoint]);

        if (distance < nextWayPointDistance)
        {
            currentWayPoint++;
        }

        ChangeSpriteToMatchDirection(force);

    }

    protected override void ChangeSpriteToMatchDirection(Vector2 f)
    {
        if (Mathf.Abs(f.x) > Mathf.Abs(f.y))
        {
            if (f.x > 0)
            {
                m_renderer.sprite = m_rightSprite;
            }
            else if (f.x < 0)
            {
                m_renderer.sprite = m_leftSprite;
            }
        }
        else {
            if (f.y > 0)
            {
                m_renderer.sprite = m_backSprite;
            }
            else if (f.y < 0)
            {
                m_renderer.sprite = m_frontSprite;
            }
        }
    }


    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (TargetedType == other.tag)

        {
            targetsReachable.Add(other.gameObject);
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if (TargetedType == other.tag)

        {
            targetsReachable.Remove(other.gameObject);
        }
    }
}
