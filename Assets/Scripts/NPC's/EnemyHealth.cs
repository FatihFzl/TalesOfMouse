using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
   
    [SerializeField] private GameObject healthPanel;
    [SerializeField] private RectTransform healthBar;
    [SerializeField] private Text healthText;

    private float healthBarStartWidth;
    private float currentHealth;
    
    [SerializeField] private float maxHealth;
    [SerializeField] private float respawnTime;

    private MeshRenderer meshRenderer;
    private bool isDead;

    public Rigidbody EnemyRigidbody { get; private set; }
    
    void Start()
    {
       healthBarStartWidth = healthBar.sizeDelta.x;
       EnemyRigidbody = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();
       // ResetHealth();
        currentHealth = 100;
        UpdateHealthUI();
    }

    public void ApplyDamage(float damage) //Apply damage yay hasarı için
    {
        if (isDead) return;

        currentHealth -= damage;
        
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            isDead = true;
            meshRenderer.enabled = false;
            healthPanel.SetActive(false);
            StartCoroutine(RespawnAfterTime());
        }

        UpdateHealthUI();
    }
         

     public void TakeDamage(float meleeDamage){ // TakeDamage yakın saldırı hasarı için 
            
            if(isDead) return;

            currentHealth -= meleeDamage;
            
            
         if (currentHealth <= 0)
        {
            currentHealth = 0;
            isDead = true;
            Destroy(gameObject);   
            //meshRenderer.enabled = false;
            healthPanel.SetActive(false);
            StartCoroutine(RespawnAfterTime());
        }

        UpdateHealthUI();
     }    

    IEnumerator RespawnAfterTime()
    {
        yield return new WaitForSeconds(respawnTime);
        //ResetHealth();
    }

    private void ResetHealth()
    {
        isDead = false;
        currentHealth = maxHealth;
        meshRenderer.enabled = true;
        healthPanel.SetActive(true);
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {        
        float percentOutOf = (currentHealth / maxHealth) * 100;
        float newWidth = (percentOutOf/ 100f) * healthBarStartWidth;

        healthBar.sizeDelta = new Vector2(newWidth, healthBar.sizeDelta.y);
        healthText.text = currentHealth + "/" + maxHealth;
    }
}

   

