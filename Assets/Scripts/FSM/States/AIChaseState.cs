using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChaseState : AIState
{
    float initialSpeed;
    public AIChaseState(AIStateAgent agent) : base(agent)
    {
        AIStateTransition transition = new AIStateTransition(nameof(AIIdleState));
        transition.AddCondition(new FloatCondition(agent.timer, Condition.Predicate.LESS, 0));
        transitions.Add(transition);

        transition = new AIStateTransition(nameof(AIAttackState));
        transition.AddCondition(new FloatCondition(agent.enemyDistance, Condition.Predicate.LESS, 2.5f));
        transitions.Add(transition);
    }

    public override void OnEnter()
    {
        agent.movement.Resume();
        initialSpeed = agent.movement.maxSpeed;
        agent.movement.maxSpeed += 2;
        agent.timer.value = 2;
    }

    public override void OnExit()
    {
        agent.movement.maxSpeed = initialSpeed;
    }

    public override void OnUpdate()
    {
        agent.movement.MoveTowards(agent.enemy.transform.position);
        if (agent.enemySeen) agent.timer.value = 2;
        //var enemies = agent.enemyPerception.GetGameObjects();
        //if (enemies.Length > 0)
        //{
        //    var enemy = enemies[0];
        //    if (Vector3.Distance(agent.transform.position, enemy.transform.position) < 1.25f)
        //    {
        //        agent.stateMachine.SetState(nameof(AIAttackState));
        //    }
        //}
        //else
        //{
        //    agent.stateMachine.SetState(nameof(AIIdleState));
        //}
    }
}
