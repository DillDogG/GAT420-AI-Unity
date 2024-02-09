using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AIDeathState : AIState
{
    public AIDeathState(AIStateAgent agent) : base(agent)
    {

    }

    public override void OnEnter()
    {
        agent.movement.Stop();
        agent.movement.Velocity = Vector3.zero;
        agent.animator?.SetTrigger("Death");

        agent.timer.value = Time.time + 4;
    }

    public override void OnExit()
    {

    }

    public override void OnUpdate()
    {
        if (Time.time >= agent.timer.value)
        {
            GameObject.Destroy(agent.gameObject);
        }
    }
}
