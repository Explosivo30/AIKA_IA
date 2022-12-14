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
    State state;
    
    public override State RunCurrentState()
    {
        Debug.Log("EnemyDetected es " + enemyDetected);
        if(enemyDetected == true)
        {
            Debug.Log("vamos al combat state");
            return combatState;
        }
        else
        {
            Debug.Log("Estoy en Follow Player");
            return this;
        }
        
    }

    private void Awake()
    {
        combatState = GetComponent<CombatState>();
        sensor = GetComponent<AiKaSensor>();
        state = GetComponent<State>();
        aika = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
       
        aika.SetDestination(player.position);
    }

    private void FixedUpdate()
    {
        if (sensor.enemyInside == true)
        {
            //TODO: Avisar al player
        }

        if (sensor.enemySeen == true)
        {
            //Estoy viendo el enemigo
            Debug.Log("Detected enemy");
            enemyDetected = true;
        }
        else
        {
            Debug.Log("Undetected Enemy");
            enemyDetected = false;
        }
        RunCurrentState();
    }


    
}
