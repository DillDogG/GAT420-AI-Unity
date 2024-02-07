using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIState : MonoBehaviour
{
    protected AIStateAgent agent;


    public AIState(AIStateAgent agent)
    {
        this.agent = agent;
    }
    public List<AIStateTransition> transitions { get; set; } = new List<AIStateTransition>();

    public abstract void OnEnter();
    public abstract void OnExit();
    public abstract void OnUpdate();
}
