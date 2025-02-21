using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CatBehaviour : MonoBehaviour
{
    
    public Transform player;
    public GameObject projectilePrefab;
    public float takipMesafesi = 15f;
    public float saldiriMesafesi = 10f;
    public float geriCekilmeMesafesi = 5f;
    public float geriCekilmeDelayi = 2f;
    public float atisHizi = 1f;
    public float geriCekilmeHizi = 5f;
    public float atisArasiBeklemeSuresi = 2f;
    public float takipHizi;
    public float distanceToPlayer;
    public float sonAtisZamani;
    private bool geriCekiliyor;
    public Animator catAnim;

    private CatStateManager stateManager;

    private void Awake()
    {
        stateManager = gameObject.GetComponent<CatStateManager>();
    }

    void Update()
    {
        distanceToPlayer = Vector3.Distance(player.position, transform.position);

        // Düşmanın oyuncuya her zaman bakmasını sağla
        Vector3 lookDirection = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(lookDirection);

 
         
         if (distanceToPlayer < geriCekilmeMesafesi) //Geri çekilme eylemi
        {
            if (!geriCekiliyor)
            {
                StartCoroutine(GeriCekil());
            }
        }
    }



    void TakipEt()
    {
             transform.position = Vector3.MoveTowards(transform.position, player.position, takipHizi * Time.deltaTime);
             catAnim.SetBool("isRunning", true);
    }

    void AtisYap()
    {
       
            catAnim.SetBool("isRunning",false);
        catAnim.SetTrigger("isBowUp");
        Instantiate(projectilePrefab, transform.position, Quaternion.LookRotation(player.position - transform.position));
        
        
        // Atış hareketleri burada gerçekleşecek
    }

    IEnumerator GeriCekil()
    {
        catAnim.SetBool("isRunning",false);
        geriCekiliyor = true;

        // Düşmanın başlangıç yükseklik pozisyonunu sakla
        float originalY = transform.position.y;

        // Düşmanın mevcut yönünün tersi olan vektörü hesapla ve y ekseni pozisyonunu sabitle
        Vector3 geriCekilmeYonu = -transform.forward * geriCekilmeHizi;
        geriCekilmeYonu.y = 0; 

        // Bir süre boyunca geriye doğru hareket et
        float geriCekilmeSuresi = 1f; 
        float baslangicZamani = Time.time;

        while (Time.time < baslangicZamani + geriCekilmeSuresi)
        {
            Vector3 newPosition = transform.position + geriCekilmeYonu * Time.deltaTime;
            newPosition.y = originalY; // Y ekseni pozisyonunu başlangıç değerinde sabitle
            transform.position = newPosition;

            yield return null;
        }

        yield return new WaitForSeconds(geriCekilmeDelayi);
        geriCekiliyor = false;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, takipMesafesi);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, saldiriMesafesi);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, geriCekilmeMesafesi);
    }
}
