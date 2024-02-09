using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AIStateMachine
{
    private Dictionary<string, AIState> states = new Dictionary<string, AIState>();
    public AIState CurrentState { get; private set; }

    public void Update()
    {
        CurrentState?.OnUpdate();
    }

    public void AddState(string name, AIState state)
    {
        Debug.Assert(!states.ContainsKey(name), "State Machine already contains state " + name);
        states[name] = state;
    }

    public void SetState(string name)
    {
        Debug.Assert(states.ContainsKey(name), "State Machine does not contain state " + name);

        var nextState = states[name];

        // exit current, set next, and enter next
        CurrentState?.OnExit();
        CurrentState = nextState;
        CurrentState?.OnEnter();
    }
}
