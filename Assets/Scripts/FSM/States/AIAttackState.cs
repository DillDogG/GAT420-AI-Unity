using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIAttackState : AIState
{
    public AIAttackState(AIStateAgent agent) : base(agent)
    {

    }

    public override void OnEnter()
    {
        agent.movement.Stop();
        agent.movement.Velocity = Vector3.zero;
        agent.animator?.SetTrigger("Attack");

        agent.timer.value = Time.time + 2;
    }

    public override void OnExit()
    {
    }

    public override void OnUpdate()
    {
        if (Time.time >= agent.timer.value)
        {
            agent.stateMachine.SetState(nameof(AIIdleState));
        }
    }
}
