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

        agent.timer.value = 2;
    }

    public override void OnExit()
    {
        Debug.Log("attack exit");
    }

    public override void OnUpdate()
    {
        Debug.Log("attack update");
    }
}
