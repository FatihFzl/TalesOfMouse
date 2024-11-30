using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    private Transform _objectTransform;
    private float _horizontalInput;
    private float _verticalInput;

    private void Awake()
    {
        _objectTransform = gameObject.transform;
    }

    private void Update()
    {
        MoveInput();
        Move();

    }

    private void Move()
    {
        Vector3 moveVector = new Vector3(_horizontalInput, 0f, _verticalInput);
        _objectTransform.position += moveVector * (_moveSpeed * Time.deltaTime);
    }

    private void MoveInput()
     {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
        
    }
}