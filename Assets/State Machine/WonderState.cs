using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WonderState : State
{
    IdleState idleState;
    CombatState combatState;
    NavMeshAgent navmesh;
    ReturnPlayerState returnPlayer;
    AiKaSensor sensor;
    State state;
    FollowPlayerState followPlayer;
    

    bool farFromPlayer = false;

    int i = 0;

    private void Awake()
    {
        state = GetComponent<State>();
        navmesh = GetComponent<NavMeshAgent>();
        sensor = GetComponent<AiKaSensor>();
    }
    public override State RunCurrentState()
    {
        //If she is wondering the player has to let you know he's being attacked to enter combat
        

        if(farFromPlayer == true)
        {
            farFromPlayer = false;
            return returnPlayer;
        }
        else if(sensor.enemyInside)
        {
            return followPlayer;
        }
        else
        {
            Debug.Log("Running WONDER STATE");
            return this;
        }
        
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

        

        if (Vector3.Distance(transform.position, state.player.transform.position) > 50f)
        {
            farFromPlayer = true;
        }
       
        
    }




}
