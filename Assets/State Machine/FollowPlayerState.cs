using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayerState : State
{
    public bool enemyDetected;
    AiKaSensor sensor;
    CombatState combatState;
    NavMeshAgent aika;
    [SerializeField] Transform player;
    
    public override State RunCurrentState()
    {
        if(enemyDetected == true)
        {
            return combatState;
        }
        Debug.Log("Estoy en Follow Player");
        return this;
    }

    private void Awake()
    {
        aika = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
       
        aika.SetDestination(player.position);
    }

    private void FixedUpdate()
    {
        if (sensor.enemyInside== true)
        {
            //TODO: Avisar al player
        }

        if (sensor.enemySeen == true)
        {
            //Estoy viendo el enemigo
            enemyDetected = true;
        }
        else
        {
            enemyDetected = false;
        }

        RunCurrentState();
    }


    
}
