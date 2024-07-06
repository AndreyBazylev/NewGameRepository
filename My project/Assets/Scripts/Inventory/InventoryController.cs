using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public static void AddItemAndSetValues(InventorySlot newItem, ChestTable newChestTable)
    {
        foreach (var index in newChestTable.Items)
        {
            if (index.ItemID == newItem.ItemID)
            {
                index.ChangeItemCount(newItem.Count);
                return;
            }
        }

        GameObject newSlot = Instantiate(newChestTable.SlotPrefab, newChestTable.InventorySlots.transform);
        newSlot.GetComponent<InventorySlot>().SetValues(newItem.ItemID, newItem.Image, newItem.Name, newItem.Count);
        newSlot.GetComponentInChildren<DragAndDropUIItem>().MyChestTable = newChestTable;
        newChestTable.Items.Add(newSlot.gameObject.GetComponent<InventorySlot>());
    }

    public static GameObject AddFastSlotItem(InventorySlot newItem, ChestTable newChestTable)
    {
        GameObject newSlot = Instantiate(newChestTable.SlotPrefab, newChestTable.InventorySlots.transform);
        
        foreach (var index in newChestTable.Items)
        {
            if (index.ItemID == newItem.ItemID)
            {
                newSlot.GetComponent<FastSlotItem>().SetValues(newItem.ItemID, newItem.Image, newItem.Name, newItem.Count + index.Count);
                newSlot.GetComponentInChildren<DragAndDropUIItem>().MyChestTable = newChestTable;
                newChestTable.Items.Add(newSlot.transform.parent.gameObject.GetComponent<InventorySlot>());
                return newSlot;
            }
        }

        newSlot.GetComponent<FastSlotItem>().SetValues(newItem.ItemID, newItem.Image, newItem.Name, newItem.Count);
        newSlot.GetComponentInChildren<DragAndDropUIItem>().MyChestTable = newChestTable;
        newChestTable.Items.Add(newSlot.transform.parent.gameObject.GetComponent<InventorySlot>());

        return newSlot;
    }

    public static void RemoveItem(InventorySlot item, ChestTable chestTable)
    {
        for (int index = 0; index < chestTable.Items.Count; index++)
        {
            if (chestTable.Items[index].ItemID == item.ItemID)
            {
                Destroy(chestTable.Items[index].gameObject);
                chestTable.Items.RemoveAt(index);
                return;
            }
        }
    }

    public void AddCountOfItemsFromDividing()
    {
        InventorySlot newItem = DragAndDropController.TranslateMyItem();
        InventorySlot remainingItem = new InventorySlot(newItem);

        newItem.Count = ItemDividingController.DivideItems();

        if (remainingItem.Count - newItem.Count > 0)
        {
            remainingItem.Count -= newItem.Count;
            AddItemAndSetValues(remainingItem, DragAndDropController.DraggingObject.GetComponentInChildren<DragAndDropShadowInventorySlot>().GetLastChest());
        }

        AddItemAndSetValues(newItem, ItemDividingController.DividingChest);
        ItemDividingController.DividingChest = null;
        ItemDividingController.CloseDividingPanel();
        Destroy(DragAndDropController.DraggingObject);
    }
}
