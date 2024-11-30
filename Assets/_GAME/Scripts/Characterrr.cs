using System;
using UnityEngine;
using UnityEngine.AI;

public partial class Characterrr : MonoBehaviour
{
    private CharacterController _cc;
    public float MoveSpeed = 5f;
    private Vector3 _movementVelocity;
    private PlayerInput _playerInput;

    private float _veritcalVelocity;
    public float Gravity = -9.8f;

    private Animator _animator;
    public Collider _swordCollider;
    
    //ENEMY
    public bool isPlayer = true;
    private NavMeshAgent _navMeshAgent;
    private Transform _targetPlayer;
    //PLAYER SLIDES
    private float _attackStartTime;
    public float AttackSlideDuration = 0.4f;
    public float AttackSlideSpeed = 0.06f;
    
    //STATE MACHINE
    public enum CharacterState
    {
        Normal, Attacking
    }

    public CharacterState currentState;

    private void Awake()
    {
        _cc = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();

        if (!isPlayer)
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _targetPlayer = GameObject.FindWithTag("Player").transform;
            _navMeshAgent.speed = MoveSpeed;
        }
        else
        {
            _playerInput = GetComponent<PlayerInput>();
        }
    }

    private void CalculatePlayerMovement()
    {
        if (_playerInput.MouseButtonDown)
        {
            SwitchState(CharacterState.Attacking);
            return;
        }
        _movementVelocity.Set(_playerInput.HorizontalInput, 0f, _playerInput.VerticalInput);
        _movementVelocity.Normalize();
        //_movementVelocity = Quaternion.Euler(0, -45f, 0) * _movementVelocity;

        _animator.SetFloat("Speed", _movementVelocity.magnitude);
        _movementVelocity *= MoveSpeed * Time.deltaTime;

        if (_movementVelocity != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(_movementVelocity);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f); // Yumuşak dönüş
        }
    }

    private void CalculateEnemyMovement()
    {
        if (Vector3.Distance(_targetPlayer.position, transform.position) >= _navMeshAgent.stoppingDistance)
        {
            _navMeshAgent.SetDestination(_targetPlayer.position);
            _animator.SetFloat("Speed", 0.2f);
        }
        else
        {
            _navMeshAgent.SetDestination(transform.position);
            _animator.SetFloat("Speed", 0f);

            SwitchState(CharacterState.Attacking);
        }
    }

    private void Update()
    {
        PerformRoll();
    }

    private void FixedUpdate()
    {
       
        switch (currentState)
        {
            case CharacterState.Normal:
                if (isPlayer)
                {
                    CalculatePlayerMovement();
                }
                else
                {
                    CalculateEnemyMovement();
                }
                break;
            case CharacterState.Attacking:
                if (isPlayer)
                {
                    _movementVelocity = Vector3.zero;
                    if (Time.time < _attackStartTime + AttackSlideDuration)
                    {
                        float timePassed = Time.time - _attackStartTime;
                        float lerpTime = timePassed / AttackSlideDuration;
                        _movementVelocity = Vector3.Lerp(transform.forward * AttackSlideSpeed, Vector3.zero, lerpTime);
                    }
                }
                break;
        }

        if (isPlayer)
        {
            if (_cc.isGrounded == false)
            {
                _veritcalVelocity = Gravity;
            }
            else
            {
                _veritcalVelocity = Gravity * 0.3f;
            }

            _movementVelocity += Vector3.up * (_veritcalVelocity * Time.deltaTime);
            _cc.Move(_movementVelocity);
        }
    }

    private void SwitchState(CharacterState newState)
    {
        if (isPlayer)
        {
            _playerInput.MouseButtonDown = false;
        }
        //Exit
        switch (currentState)
        {
            case CharacterState.Normal:
                break;
            case CharacterState.Attacking:
                break;
        }
        
        //Enter
        switch (newState)
        {
            case CharacterState.Normal:
                break;
            case CharacterState.Attacking:
                if (!isPlayer)
                {
                    Quaternion newRotation = Quaternion.LookRotation(_targetPlayer.position - transform.position);
                    transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10f); // Yumuşak dönüş
                }
                //_animator.SetTrigger("Attack");
                if (isPlayer)
                {
                    _attackStartTime = Time.time;
                }
                break;
        }

        currentState = newState;
        //Debug.Log("Switched"+currentState);
    }

    public void AttackAnimationEnds()
    {
        SwitchState(CharacterState.Normal);
    }

    public void SwordColliderEnabled()
    {
        _swordCollider.enabled = true;
    }

    public void SwordColliderDisabled()
    {
        _swordCollider.enabled = false;
    }

    public void PerformRoll()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetTrigger("Roll");
        }
    }
}

