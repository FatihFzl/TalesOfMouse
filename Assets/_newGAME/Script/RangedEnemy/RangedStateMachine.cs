using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedStateMachine : MonoBehaviour
{
    public EnemyStates currentState;
    private RangedCat rangedEnemy;
    public enum EnemyStates
    {
        Idle, Follow,Attack,Death,Dodge
    }

    public void Start()
    {
        currentState = EnemyStates.Idle;
        rangedEnemy = gameObject.GetComponent<RangedCat>();
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
                rangedEnemy.Idle();
                break;
            
            case EnemyStates.Attack:
                rangedEnemy.Attack();
                break;
            
            case EnemyStates.Follow:
                rangedEnemy.Follow();
                break;
            
            case EnemyStates.Death:
                rangedEnemy.Death();
                break;
            
            case EnemyStates.Dodge:
                rangedEnemy.Dodge();
                break;
        }
    }
}
