using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AllyBehavior : AbstractAI
{

    // Start is called before the first frame update
    protected override void Start()
    {
        TargetedType = "Enemy";
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        RegenerateAllyLive();
    }

    public override void IsDamaged(int damage)
    {
        base.IsDamaged(damage);
        m_audioManager.PlaySound(m_audioManager.m_clip, 0.5f);

    }

    private void RegenerateAllyLive()
    {
        if (m_gameManager.GetEnemiesAlive())
            SetLivesToMaximum();
    }
}
