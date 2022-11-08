using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatState : State
{

    [SerializeField] Rigidbody objectToInstantiate;
    [SerializeField] GameObject platformPlacer;
    [SerializeField] Transform playerPrediction;
    float h = 5;
    float gravity = -18;

    Rigidbody objectInstantiation;
    [SerializeField] Transform player;
    AiKaSensor sensor;
    FollowPlayerState returnPlayer;

    private void Awake()
    {
        sensor = GetComponent<AiKaSensor>();
    }



    public override State RunCurrentState()
    {

        if(sensor.playerTooFar == false)
        {
            return returnPlayer;
        }

        return this;
    }

    private void Update()
    {
        RunCurrentState();
    }


}
