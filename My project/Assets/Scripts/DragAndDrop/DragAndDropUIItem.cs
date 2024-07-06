using DevionGames.UIWidgets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DragAndDropUIItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private UnityEngine.UI.Image _myRenderer;
    [SerializeField] private Color _underMouseColor;

    [SerializeField] private GameObject _shadowInventorySlot;

    public ChestTable MyChestTable;

    private GameObject _myCanvas;

    private InventorySlot _mySlot;

    public bool PlayerOnMe = false;

    public void Start()
    {
        _mySlot = gameObject.transform.GetComponentInParent<InventorySlot>();
        _myCanvas = DragAndDropController.MainCanvas;
    }
    
    public void OnPointerEnter(PointerEventData data)
    {
        PlayerOnMe = true;

        if (Input.GetMouseButton(0) && PlayerOnMe && DragAndDropController.DraggingObject == null)
        {
            Debug.Log("hkgdihsf");
            GameObject shadowItem = Instantiate(_shadowInventorySlot, Input.mousePosition, new Quaternion(), _myCanvas.transform);
            shadowItem.GetComponent<InventorySlot>().SetValues(_mySlot.ItemID, _mySlot.Image, _mySlot.Name, _mySlot.Count);
            shadowItem.GetComponentInChildren<DragAndDropShadowInventorySlot>().SetLastChest(MyChestTable);
            DragAndDropController.DraggingObject = shadowItem;
            InventoryController.RemoveItem(gameObject.transform.parent.gameObject.GetComponent<InventorySlot>(), MyChestTable);
               
        }
    }

    public void OnPointerExit(PointerEventData data)
    {
        PlayerOnMe = false;
    }

    public void OnDrag(PointerEventData data)
    {   }
}
