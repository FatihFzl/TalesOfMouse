using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAttackState : CatBaseState
{
    public override void EnterState(CatStateManager Cat)
    {
        Debug.Log("AttackState");
    }

    public override void UpdateState(CatStateManager Cat)
    {
           if(Time.time > Cat.catBehaviour.sonAtisZamani + Cat.catBehaviour.atisArasiBeklemeSuresi){

           Object.Instantiate(Cat.catBehaviour.projectilePrefab, Cat.catBehaviour.transform.position, Quaternion.LookRotation(Cat.catBehaviour.player.position - Cat.catBehaviour.transform.position));
             Cat.catBehaviour.sonAtisZamani = Time.time;
           }
          

        if(Cat.catBehaviour.distanceToPlayer<Cat.catBehaviour.takipMesafesi && Cat.catBehaviour.distanceToPlayer>Cat.catBehaviour.saldiriMesafesi)
        {
            Cat.SwitchState(Cat.FollowState);
            }

            if(Cat.catBehaviour.distanceToPlayer < Cat.catBehaviour.geriCekilmeMesafesi){
                Cat.SwitchState(Cat.RunAwayState);
            }
        
    }

    public override void ExitState(CatStateManager Cat)
    {
        
    }
}
