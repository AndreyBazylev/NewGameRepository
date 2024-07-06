using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class ChestTable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject SlotPrefab;
    public GameObject InventorySlots;

    [HideInInspector] public List<InventorySlot> Items = new List<InventorySlot>();

    public bool _isPlayerOnMe;

    private void Update()
    {
        if (_isPlayerOnMe)
        {
            if (DragAndDropController.DraggingObject != null && Input.GetMouseButtonUp(0) && ItemDividingController.IsDividingProcessStarted == false)
            {
                TranslateItem();
            }
        }
    }

    public virtual void TranslateItem()
    {
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

    public void OnPointerEnter(PointerEventData data)
    {
        _isPlayerOnMe = true;
    }

    public void OnPointerExit(PointerEventData data)
    {
        _isPlayerOnMe = false;
    }
}
