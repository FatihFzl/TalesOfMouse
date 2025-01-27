using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFollowState : CatBaseState
{

   
    public override void EnterState(CatStateManager Cat)
    {
       Debug.Log("Follow State");
    }

    public override void UpdateState(CatStateManager Cat)
    {
        Cat.transform.position = Vector3.MoveTowards(Cat.transform.position, Cat.catBehaviour.player.position, Cat.catBehaviour.takipHizi * Time.deltaTime);
        
        if(Cat.catBehaviour.distanceToPlayer > Cat.catBehaviour.takipMesafesi){
            Cat.SwitchState(Cat.IdleState);
        }
        if(Cat.catBehaviour.distanceToPlayer< Cat.catBehaviour.saldiriMesafesi){
            Cat.SwitchState(Cat.AttackState);
        }
      
    }

    public override void ExitState(CatStateManager Cat)
    {
        
        
    }
}
