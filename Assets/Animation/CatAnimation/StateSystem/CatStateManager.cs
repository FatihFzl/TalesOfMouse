using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CatStateManager : MonoBehaviour
{
    CatBaseState currentState;

    public  CatAttackState AttackState = new CatAttackState();
    public CatFollowState FollowState = new CatFollowState();
    public CatIdleState IdleState = new CatIdleState();
    public CatRunAwayState RunAwayState = new CatRunAwayState();
    public CatBehaviour catBehaviour;

    private void Awake()
    {
        catBehaviour = gameObject.GetComponent<CatBehaviour>();
    }

    private void Start()
    {
        currentState = IdleState;
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState?.UpdateState(this);
    }

    public void SwitchState(CatBaseState state) {
         currentState = state;
         state.EnterState(this);
    }

}
