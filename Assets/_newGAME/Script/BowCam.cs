using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BowCam : MonoBehaviour
{
    public Camera gameCamera;
    public Transform characterTransform;
    public float moveDistance = 5f; // Kameranın hareket edeceği mesafe
    public float moveDuration = 1f; // Hareketin süresi
    public float reMoveDuration = 1f; // Hareketin süresi

    private PlayerRangedAttack rangedAttack;
    private Vector3 originalCameraPosition; // Kameranın orijinal pozisyonunu saklar
    private bool isMoving = false; // Kameranın hareket edip etmediğini takip eder

    void Start()
    {
        // Kameranın başlangıç pozisyonunu kaydet
        //originalCameraPosition = gameCamera.transform.position;
        rangedAttack= GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerRangedAttack>();
    }

    void Update()
    {
        // Karakter uzak mesafeli saldırı moduna girdiğinde
        if (rangedAttack.isRangedAttacking)
        {
            if (!isMoving)
            {
                // Kameranın mevcut pozisyonunu kaydet
                originalCameraPosition = gameCamera.transform.position;
                isMoving = true;
            }

            // Kameranın hedef pozisyonunu karakterin mevcut pozisyonuna göre hesapla
            Vector3 moveDirection = characterTransform.forward * moveDistance;
            Vector3 targetPosition = characterTransform.position + moveDirection;

            // Kamerayı hedef pozisyona doğru hareket ettir
            gameCamera.transform.DOMove(targetPosition, moveDuration).SetEase(Ease.Linear);
        }
        // Karakter uzak mesafeli saldırı modundan çıktığında
        else if (isMoving)
        {
            // Kamerayı orijinal pozisyonuna geri getir
            gameCamera.transform.DOMove(originalCameraPosition, reMoveDuration).SetEase(Ease.Linear);
            isMoving = false;
        }
    }
}
