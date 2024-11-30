using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeStateMachine : MonoBehaviour
{
    public EnemyStates currentState;
    private IyeEnemy _iyeEnemy;
    public enum EnemyStates
    {
        Idle, Follow,Attack,Death
    }

    public void Start()
    {
        currentState = EnemyStates.Idle;
        _iyeEnemy = gameObject.GetComponent<IyeEnemy>();
    }

    private void Update()
    {
        StateControl();
    }

    public void StateControl()
    {
        switch (currentState)
        {
            case EnemyStates.Idle:
                _iyeEnemy.Idle();
                break;
            
            case EnemyStates.Attack:
                _iyeEnemy.Attack();
                break;
            
            case EnemyStates.Follow:
                _iyeEnemy.Follow();
                break;
            
            case EnemyStates.Death:
                _iyeEnemy.Death();
                break;
        }
    }
}
