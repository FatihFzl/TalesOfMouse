using System.Collections;
using UnityEngine;
using DG.Tweening;

public class PlayerHook : MonoBehaviour
{
    [Header("Sphere")]
    public float sphereRadius;
    public float rayMaxDistance;
    public float currentHitDistance;
    [Header("Vectors")]
    public Vector3 rayOrigin;
    public Vector3 rayDirection;
    [Header("Layer")]
    public LayerMask rayLayer;
    private RaycastHit _hit;
    public bool isCasting;
    public float flyDuration;
    public Transform targetTransform;

    // Line Renderer Referansı
    public LineRenderer lineRenderer;

    private void Start()
    {
        // Line Renderer pozisyon sayısını 2 olarak ayarlayın
        lineRenderer.positionCount = 2;
        
        // Başlangıçta Line Renderer pozisyonlarını sıfırlayın
        //lineRenderer.SetPosition(0, transform.position);
        //lineRenderer.SetPosition(1, transform.position);
    }

    private void FixedUpdate()
    {
        rayOrigin = transform.position;
        rayDirection = transform.forward;

        if (Physics.SphereCast(rayOrigin, sphereRadius, rayDirection, out _hit, rayMaxDistance, rayLayer))
        {
            isCasting = true;
            Debug.Log("Hit " + _hit.collider.gameObject.name);
            currentHitDistance = _hit.distance;

            if (Input.GetKeyDown(KeyCode.F))
            {
                // Fly fonksiyonunu çağırmadan önce çizgiyi uzatın
                StartCoroutine(HookAndFly());
            }
        }
        else
        {
            currentHitDistance = rayMaxDistance;
            isCasting = false;
        }
    }

    private IEnumerator HookAndFly()
    {
        // Çizgi başlangıç pozisyonunu ayarlayın
        Vector3 start = transform.position;
        Vector3 end = _hit.point;

        float time = 0;

        // Çizgiyi uzatın
        while (time < 1)
        {
            time += Time.deltaTime / flyDuration;
            lineRenderer.SetPosition(0, start);
            lineRenderer.SetPosition(1, Vector3.Lerp(start, end, time));
            yield return null;
        }

        // Çizgi uzadıktan sonra karakteri hedefe hareket ettirin
        transform.DOMove(end, flyDuration).OnComplete(() =>
        {
            // Hareket tamamlandığında Line Renderer'ı sıfırlayın
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position);
        });
    }

    private void OnDrawGizmos()
    {
        if (isCasting)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(_hit.point, sphereRadius / 2); // Çarpma noktasında bir küre çiz
        }
        else
        {
            Gizmos.color = Color.red;
        }

        Gizmos.DrawWireSphere(transform.position + rayDirection * currentHitDistance, sphereRadius);
        Gizmos.DrawLine(transform.position, transform.position + rayDirection * currentHitDistance);
    }
}


