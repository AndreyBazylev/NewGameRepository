using DevionGames.UIWidgets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameInterfaceController : MonoBehaviour
{
    [SerializeField] private UIWidget _buildingWindow;
    [SerializeField] private UIWidget _inventoryWindow;

    private void Start()
    {
        _buildingWindow.m_KeyCode = InputManager.BuildingWindowOpenButton;
        _inventoryWindow.m_KeyCode = InputManager.InventoryWindowOpenButton;

        _inventoryWindow.Close();
        _buildingWindow.Close();
    }

    public void OpenWindowInGamePanel(UIWidget window)
    {
        _buildingWindow.Close();
        _inventoryWindow.Close();

        window.Show();
    }
}
