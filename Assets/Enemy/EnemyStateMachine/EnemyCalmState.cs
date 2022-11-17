using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCalmState : EnemyState
{
    [SerializeField] bool seenDeadBody = false;
    [SerializeField] bool seenPlayer = false;
    [SerializeField] EnemyAlertState enemyAlert;
    [SerializeField]EnemyFOV enemyFOV;
    bool pathEnded;

    float currentTimer;

    List<Transform> pathPoints = new List<Transform>();
    

    private void Awake()
    {
        enemyFOV = GetComponentInParent<EnemyFOV>();
    }
    public override EnemyState RunCurrentState()
    {
        if (seenDeadBody == true || seenPlayer == true)
        {
            seenPlayer = false;
            seenDeadBody = false;
            return enemyAlert;
        }
        else
        {
            EnemyCalmUpdate();
            return this;
        }
        
    }

    void EnemyCalmUpdate()
    {

        if (pathEnded == false)
        {
            PathPoints();
        }
        else
        {
            IdleEnemy();
        }
        
        
    }
    

    void PathPoints()
    {
        
    }

    void IdleEnemy()
    {

    }

}
