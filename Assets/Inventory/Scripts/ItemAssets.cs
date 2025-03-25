using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour {

   
    
    
    public static ItemAssets Instance { get; private set; }

    public Transform pfItemWorld;

     public Sprite healthPotionSprite;

     public Sprite manaPotionSprite;
    private void Awake() {
        Instance = this;
    }


   

}
