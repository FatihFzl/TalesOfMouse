using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    public Camera mainCamera; // Ana kameranın referansı

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AimTowardsMouse();
        }
    }

    void AimTowardsMouse()
    {
        // Fare pozisyonunu dünya koordinatlarına çevir
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero); // Y ekseninde düzlem
        float rayDistance;

        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 worldMousePosition = ray.GetPoint(rayDistance);

            // Karakterin pozisyonundan fare pozisyonuna olan yönü hesapla
            Vector3 direction = worldMousePosition - transform.position;
            direction.y = 0; // Karakterin sadece Y ekseninde dönmesini sağla

            // Karakteri bu yöne döndür
            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = targetRotation; // Direkt dönüş
            }
        }
    }
}
