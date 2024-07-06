using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class UsebleItem : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _myRenderer;
    [SerializeField] private Color _underMouseColor;

    public bool _playerIsUnderTrigger = false;

    private Color _standartColor; 

    private bool _mouseIsOver = false;

    private void Awake()
    {
        _standartColor = _myRenderer.color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerContoller>())
        {
            _playerIsUnderTrigger = true;
        } 

        if (_mouseIsOver)
        {
            _myRenderer.color = _underMouseColor;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _playerIsUnderTrigger = false;
        _myRenderer.color = _standartColor;
    }

    private void OnMouseEnter()
    {
        _mouseIsOver = true;

        if (_playerIsUnderTrigger)
        {
            _myRenderer.color = _underMouseColor;
        }
        
    }

    private void OnMouseExit()
    {
        _mouseIsOver = false;

        _myRenderer.color = _standartColor;
    }

    public virtual void Use(PlayerContoller player)
    {
        Debug.Log(gameObject.name);
    }

    public virtual void CloseWindow()
    {

    }
}
