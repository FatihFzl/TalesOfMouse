using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackControl : MonoBehaviour
{
    public GameObject hitBox;

    public void ActiveHitbox()
    {
        hitBox.SetActive(true);
    }

    public void DeActivceHitBox()
    {
        hitBox.SetActive(false);
    }
}
