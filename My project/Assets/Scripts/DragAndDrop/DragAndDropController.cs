using DevionGames.UIWidgets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropController : MonoBehaviour
{
    [SerializeField] private InventorySlot _slotPrefab;

    public static GameObject DraggingObject;
    public static GameObject MainCanvas;
    public static GameObject SlotPrefab;

    public GameObject dragObject;

    private void Update()
    {
        dragObject = DraggingObject;
    }

    private void Start()
    {
        SlotPrefab = _slotPrefab.gameObject;
        MainCanvas = GameObject.Find("MainCanvas");
    }

    public static InventorySlot TranslateMyItem()
    {
        InventorySlot slot = DraggingObject.GetComponent<InventorySlot>();
        return slot;
    }
}
