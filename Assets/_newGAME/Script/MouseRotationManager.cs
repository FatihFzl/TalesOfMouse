using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotationManager : MonoBehaviour
{
    public GameObject mainCam, player;
    private PlayerRangedAttack rangedAttack;
    private void Start()
    {
        rangedAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerRangedAttack>();
    }

    public void Update()
    {
        if (rangedAttack.isRangedAttacking == true)
        {
            CamEnable();
        }
        else if (rangedAttack.isRangedAttacking == false)
        {
            PlayerEnable();
        }
    }

    private void CamEnable()
    {
        player.GetComponent<CamRay>().enabled = true;
        mainCam.GetComponent<BowCam>().enabled = true;
        mainCam.GetComponent<ObjectCamera>().enabled = false;
        
    }

    private void PlayerEnable()
    {
        mainCam.GetComponent<ObjectCamera>().enabled = true;
        mainCam.GetComponent<BowCam>().enabled = false;
        player.GetComponent<CamRay>().enabled = false;
        
    }
}
