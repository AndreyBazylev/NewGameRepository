using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class FastSlotChestTable : ChestTable
{
    [SerializeField] private int _maxTypesOfItems;

    [SerializeField] private int _currentCountOfItems = 0;

    private bool _isMoreItems = false;

    private void Update()
    {
        if (_isPlayerOnMe)
        {
            if (DragAndDropController.DraggingObject != null && Input.GetMouseButtonUp(0) && ItemDividingController.IsDividingProcessStarted == false)
            {
                if (_currentCountOfItems >= _maxTypesOfItems)
                {
                    DecreaseCountOfItems();
                    _isMoreItems = true;
                }

                if (gameObject.transform.childCount > 0)
                {
                    if (gameObject.transform.GetChild(_maxTypesOfItems - 1).gameObject.GetComponent<FastSlotItem>().ItemID != DragAndDropController.TranslateMyItem().ItemID)
                    {
                        _currentCountOfItems++;
                        _isMoreItems = true;
                    }
                }
                
                TranslateItem();
            }
        }
    }

    public void DecreaseCountOfItems()
    {
        _currentCountOfItems--;
    }

    public void DeleteChild()
    {
        Destroy(gameObject.transform.GetChild(_maxTypesOfItems - 1).gameObject);
    }

    public override void TranslateItem()
    {  
        if (_isMoreItems)
        {
            Debug.Log("gssgdsfadgvasdsdvavasgfwdvfddfs");

            FastSlotItem tempSlot = gameObject.transform.GetChild(_maxTypesOfItems - 1).gameObject.GetComponent<FastSlotItem>();
            DeleteChild();
            InventorySlot returningToInventroySlot = new InventorySlot(tempSlot.ItemID, tempSlot.Image, tempSlot.Name, tempSlot.Count);

            _isMoreItems = false;
            InventoryController.AddItemAndSetValues(returningToInventroySlot, FastSlotsController.PlayerInventory);      
        }

        if (Input.GetKey(InputManager.DivideItemButton))
        {
            ItemDividingController.OpenDividingPanel();
            DragAndDropController.TranslateMyItem().gameObject.SetActive(false);
            ItemDividingController.SetChestToDivide(gameObject.GetComponent<ChestTable>());
            ItemDividingController.SetMaxValue(DragAndDropController.TranslateMyItem().Count);
            return;
        }

        InventoryController.AddItemAndSetValues(DragAndDropController.TranslateMyItem(), gameObject.GetComponent<ChestTable>());

        Destroy(DragAndDropController.DraggingObject);  
    }
}