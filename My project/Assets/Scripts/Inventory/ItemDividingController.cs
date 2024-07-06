using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using DevionGames.UIWidgets;

public class ItemDividingController : MonoBehaviour
{
    [SerializeField] private Slider _divideSlider;
    [SerializeField] private TMP_Text _countText;
    [SerializeField] private UIWidget _dividingPanel;

    public static ChestTable DividingChest;

    public static bool IsDividingProcessStarted = false;

    public static Slider DivideSlider;

    private static UIWidget DividingPanel;

    private void Awake()
    {
        DividingPanel = _dividingPanel;        
    }

    public void OnEnable()
    {
        DivideSlider = _divideSlider;
    }

    private void Update()
    {
        _countText.text = _divideSlider.value.ToString();
    }

    public static int DivideItems()
    {
        return Convert.ToInt32(DivideSlider.value);
    }

    public static void SetMaxValue(int value)
    {
        DivideSlider.maxValue = value;
    }

    public static void SetChestToDivide(ChestTable dividingChest)
    {
        DividingChest = dividingChest;
    }

    public static void OpenDividingPanel()
    {
        IsDividingProcessStarted = true;
        PlayerContoller.CanIMove = false;
        DividingPanel.Show();
    }

    public static void CloseDividingPanel()
    {
        IsDividingProcessStarted = false;
        PlayerContoller.CanIMove = true;
        DividingPanel.Close();
    }
}
