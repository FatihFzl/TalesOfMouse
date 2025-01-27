using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    public Animator doorAnim;
    private void OnTriggerEnter(Collider other)
    {
        // Eğer temas eden objenin etiketi "Player" ise
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player ile temas edildi!");
            // Buraya istediğiniz başka işlemleri ekleyebilirsiniz.
            doorAnim.SetBool("DoorOpen",true);
            
        }
    }
}
