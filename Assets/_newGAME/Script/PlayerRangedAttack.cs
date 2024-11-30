using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangedAttack : MonoBehaviour
{
    

    public bool isRangedAttacking;
    public Animator playerAnimator;
    public GameObject arrow,arrowPoint;
    public float arrowSpeed,arrowScale;

    private void Update()
    {
        FireControl();

    }

    private void FireControl()
    {
        if (Input.GetMouseButton(1) && isRangedAttacking == false)        //sol tıka basarsa fire true olsun
        {
            //MouseStateManager.instance.ControlAndSwitchState(MouseStateManager.instance.RangedAttackState);
            playerAnimator.SetBool("BowUp",true);
            isRangedAttacking = true;

        }

        else if (!Input.GetMouseButton(1) && isRangedAttacking == true)          //sol tıktan elini çekince ateş etmesin
        {

            //MouseStateManager.instance.ControlAndSwitchState(MouseStateManager.instance.IdleState);
            playerAnimator.SetBool("BowUp",false);
            isRangedAttacking = false;
            //weapon.Fire();
            ArrowSpawn();

        }


    }
    private void ArrowSpawn()
    {
        GameObject cloneArrow = Instantiate(arrow, arrowPoint.transform.position, arrowPoint.transform.rotation);
        cloneArrow.transform.localScale = new Vector3(arrowScale, arrowScale, arrowScale); 

        Rigidbody rbArrow = cloneArrow.GetComponent<Rigidbody>();
        rbArrow.AddForce(transform.forward*arrowSpeed,ForceMode.Impulse);


    }


}
