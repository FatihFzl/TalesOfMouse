using System;
using UnityEngine;
using DG.Tweening;
public class ObjectCamera : MonoBehaviour
{
    [SerializeField] private Transform followTransform;
    private Vector3 _offsetVector;
    [SerializeField] private Transform camTransform;
    [SerializeField] private float camMoveSpeed;
    private void LateUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        _offsetVector = new Vector3(0f, 12f, -12f);
        Vector3 finalTransform = followTransform.position + _offsetVector;
        camTransform.DOMove(finalTransform, camMoveSpeed);

    }
}
