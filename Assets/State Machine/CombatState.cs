using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatState : State
{
    public override State RunCurrentState()
    {
        return this;
    }
}
