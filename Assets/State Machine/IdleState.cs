using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    WonderState wonderState;
    public bool closeToPlayer;
    ReturnPlayerState returnPlayer;
    float countdownToMove = 5f;
    State state;



    public override State RunCurrentState()
    {
        //TODO If player is stopped 
        if (closeToPlayer == false)
        {
            return returnPlayer;
        }
        return this;
    }

    private void Awake()
    {
        state = GetComponent<State>();
    }

    private void FixedUpdate()
    {
        if(Vector3.Distance(transform.position, state.player.position) > 4f)
        {

        }

        if (state.player)
        {

        }
    }
}
