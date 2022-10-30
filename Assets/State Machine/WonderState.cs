using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WonderState : State
{
    IdleState idleState;
    CombatState combatState;
    [SerializeField] Player player;
    NavMeshAgent navmesh;
    ReturnPlayerState returnPlayer;
    
    AiKaSensor sensor;

    bool farFromPlayer = false;

    int i = 0;

    private void Awake()
    {
        navmesh = GetComponent<NavMeshAgent>();
        sensor = GetComponent<AiKaSensor>();
        idleState = GetComponent<IdleState>();
        
    }
    public override State RunCurrentState()
    {
        if (!idleState.canSeePlayer)
        {
            return combatState;
        }

        if(farFromPlayer == true)
        {
            farFromPlayer = false;
            return returnPlayer;
        }

            return this;
    }

    private void Update()
    {
        RunCurrentState();
        if(AiKaSensor.wonderPoints.Count > 0)
        {
            if (Vector3.Distance(transform.position, AiKaSensor.wonderPoints[i].position) > 1.5f)
            {
                navmesh.SetDestination(AiKaSensor.wonderPoints[i].position);
            }
            else
            {
                if (i != AiKaSensor.wonderPoints.Count - 1)
                {
                    i++;
                }
                else
                {
                    i = 0;
                }
            }
        }

        if (Vector3.Distance(transform.position, player.transform.position) > 10f)
        {
            farFromPlayer = true;
        }
       
        
    }




}
