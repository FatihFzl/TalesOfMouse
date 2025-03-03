﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemWorld : MonoBehaviour {

    private Item item;
    private SpriteRenderer spriteRenderer;
   // private TextMeshPro textMeshPro;

   public static ItemWorld SpawnItemWorld(Vector3 position, Item item){
    Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld, position, Quaternion.identity);

    ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
    itemWorld.setItem(item);

    return itemWorld;
   }
    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
     //   textMeshPro = transform.Find("Text").GetComponent<TextMeshPro>();
    }

    public void setItem(Item item){
          this.item = item;
          spriteRenderer.sprite = item.GetSprite();
    }
   
    public Item GetItem() {
        return item;
    }

    public void DestroySelf() {
        Destroy(gameObject);
    }

}
