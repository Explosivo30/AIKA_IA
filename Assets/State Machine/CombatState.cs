using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatState : State
{
    AiKaSensor sensor;
    float aiKaProtection = 1;
    bool noEnemiesInside = false;
    public override State RunCurrentState()
    {
        Debug.Log("Running combat STATE");
        return this;
        
    }

    private void Awake()
    {
        sensor = GetComponent<AiKaSensor>();
    }

    private void Update()
    {
        if(aiKaProtection > 0)
        {

        }
    }


}
