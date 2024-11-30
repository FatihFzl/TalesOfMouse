using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTest : MonoBehaviour
{
    public Animator animator;
    public int attackCount;
    public float countResetTime;
    private Coroutine resetCoroutine;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (resetCoroutine != null)
            {
                StopCoroutine(resetCoroutine);
            }

            CheckAttackCount();
            animator.SetTrigger("Attack" + attackCount);
            resetCoroutine = StartCoroutine(ResetAttackCount());
        }
    }
    private void CheckAttackCount()
    {
        if (attackCount < 3) 
            attackCount++;
    }

    IEnumerator ResetAttackCount()
    {
        yield return new WaitForSeconds(countResetTime);
        attackCount = 0;
    }
}
