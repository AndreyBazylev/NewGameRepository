using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevionGames.UIWidgets;
using ContextMenu = DevionGames.UIWidgets.ContextMenu;
using UnityEngine.EventSystems;

public class ContextMenuTrigger : MonoBehaviour
{
    private PlayerContoller _player;

    private ContextMenu m_ContextMenu;

    private UsebleItem _myItem;

    public string[] menu;

    private void Start()
    {
        this.m_ContextMenu = WidgetUtility.Find<ContextMenu>("ContextMenu");
        _player = GameObject.FindWithTag("Player").GetComponent<PlayerContoller>();

        _myItem = gameObject.GetComponent<UsebleItem>();
    }

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) && _myItem._playerIsUnderTrigger)
        {
            this.m_ContextMenu.Clear();
            for (int i = 0; i < menu.Length; i++)
            {
                string menuItem = menu[i];
                m_ContextMenu.AddMenuItem(menuItem, delegate { _myItem.Use(_player); }) ;
            }
            this.m_ContextMenu.Show();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        this.m_ContextMenu.Close();
        this._myItem.CloseWindow();
    }
}
