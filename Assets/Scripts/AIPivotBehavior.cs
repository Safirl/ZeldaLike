using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AIPivotBehavior : MonoBehaviour
{
    public GameObject m_AIParent;
    public EnemyBehavior m_EnemyBehavior;
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        m_EnemyBehavior = m_AIParent.GetComponent<EnemyBehavior>();
        target = m_EnemyBehavior.GetTarget();
    }

    // Update is called once per frame
    void Update()
    {
        
        setSwordPosition();
    }

    public void setSwordPosition()
    {

        if (target != null)
        {
            target = m_EnemyBehavior.GetTarget();
            Vector3 direction = target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            transform.rotation = rotation;
        }
        /*Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.forward);
        transform.rotation = rotation;*/
    }
}
