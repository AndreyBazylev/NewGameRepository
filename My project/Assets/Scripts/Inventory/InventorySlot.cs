using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] protected Image ItemIcon;
    [SerializeField] protected TMP_Text ItemName;
    [SerializeField] protected TMP_Text ItemCount;
    [SerializeField] protected InventoryAnimationController _myAnimator;

    [HideInInspector] public Sprite Image;
    [HideInInspector] public string Name;
    [HideInInspector] public int Count;
    
    public int ItemID;

    public InventorySlot()
    { }

    public InventorySlot(int itemID, Sprite image, string name, int count)
    {
        Count = count;
        Name = name;
        Image = image;
        ItemID = itemID;
    }

    public InventorySlot(InventorySlot slot)
    {
        Count = slot.Count;
        Name = slot.Name;
        Image = slot.Image;
        ItemID = slot.ItemID;
    }

    public void SetValues(int newID, Sprite image, string name, int count)
    {
        ItemID = newID;
        ItemCount.text = count.ToString();
        ItemName.text = name;
        ItemIcon.sprite = image;

        Count = count;
        Image = image;
        Name = name;


        if (_myAnimator != null)
        {
            _myAnimator.AddItemToSlot();
        }
    }

    public virtual void ChangeItemCount(int newCount)
    {
        Count += newCount;
        ItemCount.text = Count.ToString();

        if (_myAnimator != null)
        {
            _myAnimator.AddItemToSlot();
        }
    }

    public void SetUnselectedCount()
    {
        ItemCount.text = "~";
    }

    public void SetRealCount()
    {
        ItemCount.text = Count.ToString();
    }
}
