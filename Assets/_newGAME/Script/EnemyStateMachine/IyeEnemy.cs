using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IyeEnemy : MonoBehaviour
{
    public Transform player;
    public float attackDistance = 5.0f;
    public float chaseDistance = 10.0f;
    public float chaseSpeed = 5.0f;
    public float attackDelay = 2.0f;
    public int damage = 10;
    public Animator enemyAnim;
    private float lastAttackTime;
    private MeleeStateMachine _stateMachine;
    private CubeEnemy heatlh;

    private void Start()
    {
        _stateMachine = gameObject.GetComponent<MeleeStateMachine>();
        heatlh = gameObject.GetComponent<CubeEnemy>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        // Düşmanın oyuncuya her zaman bakmasını sağla
        Vector3 lookDirection = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(lookDirection);

        if (distanceToPlayer < chaseDistance)
        {
            // Saldırı mesafesinde değilse takip et
            if (distanceToPlayer > attackDistance)
            {
                //StartCoroutine(FollowDelay());
                _stateMachine.currentState = MeleeStateMachine.EnemyStates.Follow;
            }
            else
            {
                // Saldırı mesafesindeyse ve beklemesi gerekiyorsa
                if (Time.time > lastAttackTime + attackDelay)
                {
                    _stateMachine.currentState = MeleeStateMachine.EnemyStates.Attack;
                    lastAttackTime = Time.time;
                }
                else
                {
                    // Saldırı beklerken koşma animasyonunu durdur
                    _stateMachine.currentState = MeleeStateMachine.EnemyStates.Idle;
                }
            }
        }
        else
        {
            // Takip mesafesinde değilse animasyonları durdur
            _stateMachine.currentState = MeleeStateMachine.EnemyStates.Idle;
        }
        if (heatlh.health <= 0)
        {
            _stateMachine.currentState = MeleeStateMachine.EnemyStates.Death;
            //enemyAnimator.SetBool("Dead",true);
            Debug.Log("EnemyDead");
        }
    }
    
    public void Follow()
    {
        //Debug.Log("FollowUpdating");
        var position = transform.position;
        position = Vector3.MoveTowards(position, player.position, chaseSpeed * Time.deltaTime);
        position.y = 0;
        transform.position = position;
        enemyAnim.SetBool("isRunning", true);
    }

    public void Attack()
    {
        //Debug.Log("AttackUpdating");
        enemyAnim.SetTrigger("isAttacking");
    }

    public void Idle()
    {
        //Debug.Log("IdleUpdating");
        enemyAnim.SetBool("isRunning", false);
        enemyAnim.SetBool("isAttacking", false);
    }

    public void Death()
    {
        //Debug.Log("DeathUpdating");
        enemyAnim.SetBool("Dead",true);
        
    }
    void OnDrawGizmos()
    {
        // Kovalama mesafesi için mavi bir çember çiz
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, chaseDistance);

        // Saldırı mesafesi için kırmızı bir çember çiz
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }

    private IEnumerator FollowDelay()
    {
        yield return new WaitForSeconds(1f);
        _stateMachine.currentState = MeleeStateMachine.EnemyStates.Follow;
    }
}

