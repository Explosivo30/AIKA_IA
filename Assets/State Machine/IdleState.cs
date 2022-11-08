using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    WonderState wonderState;
    public bool canSeePlayer;
    FollowPlayerState returnPlayer;
    public override State RunCurrentState()
    {
        //TODO If player is stopped 
        if (canSeePlayer == false)
        {
            return returnPlayer;
        }
        return this;
    }
}
