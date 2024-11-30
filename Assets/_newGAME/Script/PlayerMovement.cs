using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   private Transform _playerTransform;
   private Rigidbody _playerRb;
  
   [Header("Movement")]
   public float moveSpeed;
   public float rotationSpeed;
   [Header("Dash")]
   public float dashDuration;
   public float lastDashTime;
   public float dashCooldown;
   public bool isDashing;
   public float dashSpeed;
   
   private float _horizontalInput;
   private float _verticalInput;
   
   
   private void Start()
   {
      _playerTransform = GetComponent<Transform>();
      _playerRb = GetComponent<Rigidbody>();
   }

   private void Update()
   {
      GetInput();
      Move();
      Rotate();
      
      if (Input.GetKeyDown(KeyCode.Space) && Time.time > lastDashTime + dashCooldown && !isDashing) // Space tuşuna basılması, cooldown süresinin dolmuş olması ve dash yapılıyor olmaması kontrolü
      {
         StartCoroutine(PerformDash());
      }
   }

   
   
   private void Move()
   {
      _playerTransform.position += new Vector3(_horizontalInput, 0f, _verticalInput) * (moveSpeed * Time.deltaTime);
   }

   private void Rotate()
   {
      Vector3 direction = new Vector3(_horizontalInput, 0f, _verticalInput);
      if (direction != Vector3.zero)  // Sıfır vektörü değilse, yani bir girdi varsa
      {
         Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
         _playerTransform.rotation = Quaternion.RotateTowards(_playerTransform.rotation, toRotation, (rotationSpeed*100) * Time.deltaTime);
      }
   }

   private IEnumerator PerformDash()
   {
      isDashing = true;
      Vector3 dashVelocity = _playerRb.transform.forward * dashSpeed;
      _playerRb.velocity = dashVelocity;
      lastDashTime = Time.time;

      yield return new WaitForSeconds(dashDuration); // Dash süresi kadar bekle

      _playerRb.velocity = Vector3.zero; // Dash sonunda hızı sıfırla
      isDashing = false;
      
   }

   private void GetInput()
   {
      _horizontalInput = Input.GetAxisRaw("Horizontal");
      _verticalInput = Input.GetAxisRaw("Vertical");
   }
}
