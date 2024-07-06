using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastSlotsController : MonoBehaviour
{
    [SerializeField] private List<FastSlot> _slots;
    [SerializeField] private FastSlotPointer _myPointer;

    [SerializeField] private ChestTable _playerInventory;
    
    public static ChestTable PlayerInventory;

    private int _currentSlot = 0;

    private static FastSlotsController _staticFastSlotController;

    private void Start()
    {
        PlayerInventory = _playerInventory;
        _staticFastSlotController = gameObject.GetComponent<FastSlotsController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(InputManager.NextFastSlotButton))
        {
            MoveToSlot(true);
            return;
        }

        if (Input.GetKeyDown(InputManager.PreviousFastSlotButton))
        {
            MoveToSlot(false);
            return;
        }
    }

    public static void MoveToSlotAtIndex(int index)
    {
        if (index < _staticFastSlotController._slots.Count && index >= 0)
        {
            _staticFastSlotController._myPointer.MoveMe(_staticFastSlotController._slots[index]);
            _staticFastSlotController._currentSlot = index;
        }
    }

    public void MoveToMyIndexByButton(int index)
    {
        _staticFastSlotController._myPointer.MoveMe(_staticFastSlotController._slots[index]);
        _staticFastSlotController._currentSlot = index;
    }

    private void MoveToSlot(bool isNextSlot)
    {
        if (isNextSlot && _currentSlot + 1 < _slots.Count)
        {
            _myPointer.MoveMe(_slots[_currentSlot + 1]);
            _currentSlot++;
        }

        else if (!isNextSlot && _currentSlot - 1 >= 0)
        {
            _myPointer.MoveMe(_slots[_currentSlot - 1]);
            _currentSlot--;
        }


    }
}
