using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatState : State
{
    AiKaSensor sensor;
    ReturnPlayerState returnPlayer;

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
