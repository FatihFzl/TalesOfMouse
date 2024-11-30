using System;
using UnityEngine;
using DG.Tweening;

public class CameraProp : MonoBehaviour
{
    public float duration;
    public float strength;
    public int vibrato;
    public float randomness;
    public void CamAttackShake()
    {
        Debug.Log("Camera sallandı");
        gameObject.transform.DOShakePosition(duration, strength, vibrato, randomness);

    }

    public void Update()
    {
        CamShakeTest();
    }

    public void CamShakeTest()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }
    }
}
