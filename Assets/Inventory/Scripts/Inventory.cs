using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory {

    public event EventHandler OnItemListChanged;
    private List<Item> itemList;
 
    public Inventory() {
       
        itemList = new List<Item>();

        AddItem(new Item { itemType = Item.ItemType.HealthPotion, amount = 1 });
        
       
    }

    public void AddItem(Item item) {
        if(item.IsStackable()){
            bool itemAlreadyInInventory = false;
             if (!itemAlreadyInInventory){
                itemList.Add(item);
            }
           foreach(Item inventoryItem in itemList){
            if (inventoryItem.itemType == item.itemType){
                inventoryItem.amount += item.amount;
                itemAlreadyInInventory = true;
            }
           
           }
        } else{
            itemList.Add(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
        
         Debug.Log(itemList.Count);
    }


    public List<Item> GetItemList() {
        return itemList;
    }

}
