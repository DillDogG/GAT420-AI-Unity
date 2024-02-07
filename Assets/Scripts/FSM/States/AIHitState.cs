using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHitState : AIState
{
    public AIHitState(AIStateAgent agent) : base(agent)
    {

    }

    public override void OnEnter()
    {
        agent.movement.Stop();
        agent.movement.Velocity = Vector3.zero;
        agent.animator?.SetTrigger("Hit");

        agent.timer.value = 2;
    }

    public override void OnExit()
    {

    }

    public override void OnUpdate()
    {

    }
}
