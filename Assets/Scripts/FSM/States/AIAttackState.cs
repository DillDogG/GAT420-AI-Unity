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
        Debug.Log("attack enter");
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
