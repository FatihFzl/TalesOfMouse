using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatRunAwayState : CatBaseState
{
   

    public override void EnterState(CatStateManager Cat)
    {
       Debug.Log("RunAway State");
    }

    public override void UpdateState(CatStateManager Cat)
    {
        if(Cat.catBehaviour.distanceToPlayer< Cat.catBehaviour.saldiriMesafesi){
            Cat.SwitchState(Cat.AttackState);
        }
        
    }

    public override void ExitState(CatStateManager Cat)
    {
        
    }
}
