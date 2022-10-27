using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnPlayerState : State
{
    public override State RunCurrentState()
    {
        Debug.Log("Estoy en Return player");
        return this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RunCurrentState();
    }
}
