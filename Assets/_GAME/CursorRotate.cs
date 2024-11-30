using UnityEngine;

public class CursorRotate : MonoBehaviour
{
    public Camera cam; // Oyun kamerası referansı
    public float turnSpeed = 5f; // Dönüş hızını ayarlamak için bir değişken

    private Quaternion targetRotation; // Hedef rotasyonumuz

    void Update()
    {
        // Mouse tıklandığında
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Tıklanan yere bakacak şekilde hedef rotasyonu hesapla
                Vector3 targetDirection = hit.point - transform.position;
                targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
            }
            // Dönmekte olan karakter için slerp kullanarak yavaşça hedef rotasyona dön
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * turnSpeed);
        }

        
    }
}