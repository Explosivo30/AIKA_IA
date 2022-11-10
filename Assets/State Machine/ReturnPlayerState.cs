using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ReturnPlayerState : State
{
    public bool enemyDetected = false;
    AiKaSensor sensor;
    CombatState combatState;
    NavMeshAgent aika;
    State state;
    public override State RunCurrentState()
    {
        if (enemyDetected == true)
        {
            return combatState;
        }
        Debug.Log("Estoy en Follow Player");
        return this;
    }

    private void Awake()
    {
        state = GetComponent<State>();
        aika = GetComponent<NavMeshAgent>();
        sensor = GetComponent<AiKaSensor>();
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
