using DevionGames.UIWidgets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropShadowInventorySlot : DragPanel, IDragHandler
{
    [SerializeField] private ChestTable _myLastChest;

    private void Update()
    {
        transform.position = Input.mousePosition;

        if (Input.GetMouseButtonUp(0))
        {
            InventoryController.AddItemAndSetValues(DragAndDropController.TranslateMyItem(), _myLastChest);
            Destroy(gameObject.transform.parent.gameObject);
        }

        if (Input.GetKey(InputManager.DivideItemButton))
        {
            gameObject.transform.parent.GetComponent<InventorySlot>().SetUnselectedCount();
        }

        if (Input.GetKeyUp(InputManager.DivideItemButton))
        {
            gameObject.transform.parent.GetComponent<InventorySlot>().SetRealCount();
        }
    }

    public void SetLastChest(ChestTable lastChest)
    {
        _myLastChest = lastChest;
    }

    public ChestTable GetLastChest()
    {
        return _myLastChest;
    }
}
