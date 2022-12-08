using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class EnemyAgressiveState : EnemyState
{
    EnemyFOV enemyFOV;

    bool chasePlayer = false;

    float timeToAttack;
    float timeResetAttack = 3f;
    NavMeshAgent navMeshAgent;

    [SerializeField] EnemyAlertState alertState;

    bool isInside = true;
    
    //MAKE IT FASTER

    //RANGE
    //
    //ATTACK

    private void Awake()
    {
        navMeshAgent = GetComponentInParent<NavMeshAgent>();
        enemyFOV = GetComponentInParent<EnemyFOV>();
    }

    public override EnemyState RunCurrentState()
    {
        if (isInside == false)
        {
            return alertState;
        }
        else
        {
            UpdateAgressive();
            
            return this;
        }
    }

    private void UpdateAgressive()
    {
        
        if (enemyFOV.GetPlayerInside() == true)
        {
            navMeshAgent.isStopped = true;
            timeToAttack -= Time.deltaTime;
            AttackPlayer();
        }
        else
        {

            timeToAttack = timeResetAttack;
            navMeshAgent.isStopped = false;
            //Last time we saw the player, Save Vector3;
            //navMeshAgent.SetDestination()
        }
    }

    private void AttackPlayer()
    {
        
        transform.LookAt(enemyFOV.GetPlayerPos());
        if (timeToAttack < 0)
        {
            //playerAttack
            timeToAttack = timeResetAttack;
        }


    }

    

    void SetIsInside(bool isInside)
    {
        this.isInside = isInside;  
    }

}
