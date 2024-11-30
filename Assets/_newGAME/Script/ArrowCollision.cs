using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCollision : MonoBehaviour
{
    private string _targetTag;
    private GameObject _cubeEnemyObject;
    private CubeEnemy _cubeEnemy;
    
    private void Start()
    {
        _targetTag = "Enemy";
        
        _cubeEnemyObject= GameObject.FindGameObjectWithTag(_targetTag);
        
        _cubeEnemy = _cubeEnemyObject.GetComponent<CubeEnemy>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_targetTag))
        {
            _cubeEnemy.Hit();
            _cubeEnemy.TakeDamage(1);
            Destroy(gameObject);
            
        }
    }
}
