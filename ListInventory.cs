using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class ListInventory : MonoBehaviour {
    [SerializeField] private GameObject InventoryCellPrefab;
    [SerializeField] private GameObject InventoryCellParent;
    private List<InventoryCell> InventoryCells;

    void Start() {
        InventoryCells =  new List<InventoryCell>();
    }

    public void AddItem(Item ItemToAdd){
        InventoryCell CellWithItem = InventoryCells.Find((x) => x.GetItem().ItemName == ItemToAdd.ItemName);
        if(CellWithItem !=null)
        {
            CellWithItem.AddToCount(1);
            return;
        }

        GameObject NewCell = InstantLate(InventoryCellPrefab, InventoryCellParent.transform);
        InventoryCell CellInstance = NewCell.GetComponent<InventoryCell>();

        CellInstance.Initialize(this);
        InventoryCells.Add(CellInstance);
    }

    public void DropItem(GameObject InventiryCellInstance){
        InventoryCell TargetCell = InventoryCells.Find((x) => x.GetCellInstance().GetInstanceID() == InventiryCellInstance.GetInstanceID());
        if(TargetCell.GetCount == 1){
            InventoryCells.Remove(TargetCell);
            TargetCell.RemoveCell();
        }
        else if(TargetCell.GetCount() < 1){
            TargetCell.AddToCount(-1);
        }
    }


}
