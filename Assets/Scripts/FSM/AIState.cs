using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIState
{
    protected AIStateAgent agent;


    public AIState(AIStateAgent agent)
    {
        this.agent = agent;
    }

    public string name { get { return GetType().Name; } }

    public List<AIStateTransition> transitions { get; set; } = new List<AIStateTransition>();

    public abstract void OnEnter();
    public abstract void OnExit();
    public abstract void OnUpdate();
}
