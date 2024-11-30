using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEnemy : MonoBehaviour
{
    public Animator enemyAnimator;
    public int health;
    public MeleeStateMachine _stateMachine;
    

    public void Hit()
    {
        Debug.Log("Hitted");
        Rigidbody rb = GetComponent<Rigidbody>();
        
        rb.AddForce(new Vector3(5f,0f,0f),ForceMode.Impulse);
        enemyAnimator.SetTrigger("Damage");
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        
    }
}
