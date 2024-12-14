using System.Net.Mime;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using TMpro;


public class Inventory : MonoBehaviour {

   [SerializeField] private TextMeshProUGUI ItemNameDis;

   [SerializeField] private Image ItemImgDis;
   [SerializeField] private Button Drop Button;

   private Item Current;
   private int Count;

    public void Initialize(ListInventory InventoryMan){
          DropButton.onClick.AddListener(new UnityEngine.Events.UnityAction(delegate(InventoryMan.DropItem(this);)));
          
    }

    public void AddToCount(int Amount){
        Count += Amount;
        ItemNameDis.SetText($"{Current.ItemName} {Count}x");
    }

    public void SetItem(Item ItemToSet){
        Count = 1;
        ItemNameDis.SetText($"{Current.ItemName} {Count}x");
        ItemImgDis.sprite = ItemToSet.ItemImage;
        Current = ItemToSet;
    }

    public GameObject GetCellInstance(){
        return gameObject;
    }
    public Item GetItem(){
        return Current;
    }
    public int GetCount(){
        return Count;
    }
    public void RemoveCell(){
        Destroy(gameObject)
    }
    
}