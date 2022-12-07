using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAgressiveState : EnemyState
{
    EnemyFOV enemyFOV;

    [SerializeField] EnemyAlertState alertState;

    bool isInside = true;
    
    //MAKE IT FASTER

    //RANGE
    //
    //ATTACK

    private void Awake()
    {
        enemyFOV = GetComponentInParent<EnemyFOV>();
    }

    public override EnemyState RunCurrentState()
    {
        if (isInside == false)
        {
            return alertState;
        }
        else
        {

            return this;
        }
    }
    

    void SetIsInside(bool isInside)
    {
        this.isInside = isInside;  
    }

}
