using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatIdleState : CatBaseState
{
    

    public override void EnterState(CatStateManager Cat)
    {
        Debug.Log("Idle Statede şu an");
        
    }

    public override void UpdateState(CatStateManager Cat)
    {
        if(Cat.catBehaviour.distanceToPlayer<Cat.catBehaviour.takipMesafesi && Cat.catBehaviour.distanceToPlayer>Cat.catBehaviour.saldiriMesafesi)
        {
            Cat.SwitchState(Cat.FollowState);
            }
        
       
    }

    public override void ExitState(CatStateManager Cat)
    {
        
    }
}
