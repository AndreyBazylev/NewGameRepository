using DevionGames.UIWidgets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBox : UsebleItem
{
    [SerializeField] private UIWidget _myWidget;

    public override void Use(PlayerContoller player)
    {
        _myWidget.Show();
    }

    public override void CloseWindow()
    {
        _myWidget.Close();
    }
}
