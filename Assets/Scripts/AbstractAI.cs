using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AbstractAI : AbstractCharacter
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float nextWayPointDistance = 3f;

    protected Path path;
    protected int currentWayPoint = 0;
    protected bool reachedEndOfPath = false;

    protected Seeker seeker;
    protected string TargetedType;
    protected ArrayList targetsReachable;
    float closestDistance;
    



    // Start is called before the first frame update
    protected virtual void Start()
    {
        seeker = GetComponent<Seeker>();

        InvokeRepeating("UpdatePath", 0f, 0.5f);
        InvokeRepeating("ChoseTargetToAttack", 0f, 0.3f);
    }
    public void ChoseTargetToAttack()
    {
        Debug.Log(targetsReachable);
        foreach (GameObject targetReachable in targetsReachable)
        {
            float distance = Vector2.Distance(transform.position, targetReachable.transform.position);

            if (distance < closestDistance)
            {
                target = targetReachable.transform;
            }
        }
    }

    public void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(m_rb2D.position, target.position, OnPathComplete);
        
    }

    public void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWayPoint = 0;
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