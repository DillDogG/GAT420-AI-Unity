using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrolState : AIState
{
    Vector3 destination;
    public AIPatrolState(AIStateAgent agent) : base(agent)
    {
        AIStateTransition transition = new AIStateTransition(nameof(AIIdleState));
        transition.AddCondition(new FloatCondition(agent.destinationDistance, Condition.Predicate.LESS, 1));
        transitions.Add(transition);
    }

    public override void OnEnter()
    {
        agent.movement.Resume();

        var navNode = AINavNode.GetRandomAINavNode();
        destination = navNode.transform.position;
    }

    public override void OnExit()
    {

    }

    public override void OnUpdate()
    {
        agent.movement.MoveTowards(destination);
        if (Vector3.Distance(agent.transform.position, destination) < 1 )
        {
            agent.stateMachine.SetState(nameof(AIIdleState));
        }

        var enemies = agent.enemyPerception.GetGameObjects();
        if (enemies.Length > 0 )
        {
            agent.stateMachine.SetState(nameof(AIChaseState));
        }
    }
}
