using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item {

    public enum ItemType {
        HealthPotion
    }

    public ItemType itemType;
    public int amount;


    public Sprite GetSprite(){
        switch(itemType){
            default:
            case ItemType.HealthPotion: return ItemAssets.Instance.healthPotionSprite;
        }
    }
}
