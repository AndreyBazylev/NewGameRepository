using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FastSlotItem : InventorySlot
{
    public FastSlotItem()
    { }

    public FastSlotItem(int itemID, Sprite image, string name, int count)
    {
        Count = count;
        Name = name;
        Image = image;
        ItemID = itemID;
    }

    public FastSlotItem(InventorySlot slot)
    {
        Count = slot.Count;
        Name = slot.Name;
        Image = slot.Image;
        ItemID = slot.ItemID;
    }

    public void SetValues(int newID, Image image, string name, TMP_Text count)
    {
        ItemID = newID;

        ItemIcon = image;
        ItemCount = count;

        Count = Convert.ToInt32(count);
        Image = image.sprite;
        Name = name;

        if (_myAnimator != null)
        {
            _myAnimator.AddItemToSlot();
        }
    }
}
