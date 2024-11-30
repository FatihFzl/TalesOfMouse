using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRay : MonoBehaviour
{
    public Camera orthographicCamera;
    public LayerMask groundLayer; // Karakterin üzerinde durduğu zemin için bir LayerMask değişkeni.

    void Update()
    {
        Ray ray = orthographicCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
        {
            // Y ekseni etrafında dönmeyi sabitle ve karakteri z ekseninde döndür
            Vector3 lookAtPosition = hit.point;
            lookAtPosition.y = transform.position.y;

            // Karakteri hedefe doğru döndür
            transform.LookAt(lookAtPosition);
        }
    }
}
