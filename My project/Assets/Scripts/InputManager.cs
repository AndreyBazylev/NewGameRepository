using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public static KeyCode DivideItemButton;
    [SerializeField] private KeyCode _divideItemButton = KeyCode.LeftControl;

    public static KeyCode BuildingWindowOpenButton;
    [SerializeField] private KeyCode _buildingWindowOpenButton = KeyCode.B;

    public static KeyCode InventoryWindowOpenButton;
    [SerializeField] private KeyCode _inventoryWindowOpenButton = KeyCode.I;

    #region FastSlots

    public static KeyCode NextFastSlotButton;
    [SerializeField] private KeyCode _nextFastSlotButton = KeyCode.E;

    public static KeyCode PreviousFastSlotButton;
    [SerializeField] private KeyCode _previousWindowOpenButton = KeyCode.Q;

    public static KeyCode FirstFastSlot;
    [SerializeField] private KeyCode _firstFastSlot = KeyCode.Alpha1;

    public static KeyCode SecondFastSlot;
    [SerializeField] private KeyCode _secondFastSlot = KeyCode.Alpha2;

    public static KeyCode ThirdFastSlot;
    [SerializeField] private KeyCode _thirdFastSlot = KeyCode.Alpha3;

    public static KeyCode FourthFastSlot;
    [SerializeField] private KeyCode _fourthFastSlot = KeyCode.Alpha4;

    public static KeyCode FifthFastSlot;
    [SerializeField] private KeyCode _fifthFastSlot = KeyCode.Alpha5;

    public static KeyCode SixthFastSlot;
    [SerializeField] private KeyCode _sixthFastSlot = KeyCode.Alpha6;

    public static KeyCode SeventhFastSlot;
    [SerializeField] private KeyCode _seventhFastSlot = KeyCode.Alpha7;

    public static KeyCode EightsFastSlot;
    [SerializeField] private KeyCode _eightsFastSlot = KeyCode.Alpha8;

    public static KeyCode NinethFastSlot;
    [SerializeField] private KeyCode _ninethFastSlot = KeyCode.Alpha9;

    [SerializeField] public UnityAction<int> _FastSlotsButtonPressed;

    #endregion

    private void Start()
    {
        DivideItemButton = _divideItemButton;
        BuildingWindowOpenButton = _buildingWindowOpenButton;
        InventoryWindowOpenButton = _inventoryWindowOpenButton;

        #region FastSlots

        NextFastSlotButton = _nextFastSlotButton;
        PreviousFastSlotButton = _previousWindowOpenButton;
        FirstFastSlot = _firstFastSlot;
        SecondFastSlot = _secondFastSlot;
        ThirdFastSlot = _thirdFastSlot;
        FourthFastSlot = _fourthFastSlot;
        FifthFastSlot = _fifthFastSlot;
        SixthFastSlot = _sixthFastSlot;
        SeventhFastSlot = _seventhFastSlot;
        EightsFastSlot = _eightsFastSlot;
        NinethFastSlot = _ninethFastSlot;

        _FastSlotsButtonPressed += FastSlotsController.MoveToSlotAtIndex;

        #endregion
    }

    private void Update()
    {
        #region FastSlots
        
        if (Input.GetKeyDown(FirstFastSlot))  
            _FastSlotsButtonPressed.Invoke(0);

        if (Input.GetKeyDown(SecondFastSlot))
            _FastSlotsButtonPressed.Invoke(1);

        if (Input.GetKeyDown(ThirdFastSlot))
            _FastSlotsButtonPressed.Invoke(2);

        if (Input.GetKeyDown(FourthFastSlot))
            _FastSlotsButtonPressed.Invoke(3);

        if (Input.GetKeyDown(FifthFastSlot))
            _FastSlotsButtonPressed.Invoke(4);

        if (Input.GetKeyDown(SixthFastSlot))
            _FastSlotsButtonPressed.Invoke(5);

        if (Input.GetKeyDown(SeventhFastSlot))
            _FastSlotsButtonPressed.Invoke(6);

        if (Input.GetKeyDown(EightsFastSlot))
            _FastSlotsButtonPressed.Invoke(7);

        if (Input.GetKeyDown(NinethFastSlot))
            _FastSlotsButtonPressed.Invoke(8);
        #endregion
    }
}
