using System;
using UnityEngine;
public class ObjectRotation: MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Vector3 test;

    private void Update()
    {
        Rotate();
        transform.rotation = Quaternion.Euler(test);
    }

    private void Rotate()
    {
        
    }
    
}