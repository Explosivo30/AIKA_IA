using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    State currentState;
    
    private void Update()
    {
        RunStateMachine();
    }

    void RunStateMachine()
    {
        //If next state is not null run current State
        State nextState = currentState?.RunCurrentState();
        if(nextState != null)
        {
            //Switch to next state
            SwitchToTheNextState(nextState);
        }
    }

    void SwitchToTheNextState(State nextState)
    {
        currentState = nextState;
    }

}
