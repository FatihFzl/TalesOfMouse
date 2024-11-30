using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IyeAttack : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Animator>().SetTrigger("Damage");
            Debug.Log("Oldu");
        }
    }
}
