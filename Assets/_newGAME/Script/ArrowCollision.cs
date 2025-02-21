using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCollision : MonoBehaviour
{
 
    public int arrowDamage;
   
    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.CompareTag("ArcherEnemy")){
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(arrowDamage);
            Destroy(gameObject);
        }
        
        if(other.gameObject.CompareTag("Enemy")){
            other.gameObject.GetComponent<CubeEnemy>().TakeDamage(arrowDamage);
             other.gameObject.GetComponent<CubeEnemy>().Hit();
             Destroy(gameObject);
        }
     
    }
}
