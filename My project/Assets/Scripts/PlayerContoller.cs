using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rgBody;
    [SerializeField] EntityAnimationController _myAnimationController;
    [SerializeField] private float _useRange = 1f;

    public InventoryController _myInventoryController;
    public ChestTable _myChest;

    private float _horizontalInput;
    private float _verticalInput;
    private Vector2 _currentDirection = Vector2.down;

    public float runSpeed = 3.5f;

    public static bool CanIMove = true;

    void Update()
    {
        if (CanIMove)
        {
            _horizontalInput = Input.GetAxisRaw("Horizontal");
            _verticalInput = Input.GetAxisRaw("Vertical");
        }
    }

    private void FixedUpdate()
    {
        _rgBody.velocity = new Vector2(_horizontalInput * runSpeed, _verticalInput * runSpeed);

        if (_horizontalInput == 0 && _verticalInput == 0)
        {
            _myAnimationController.StartIdle();
        }

        else if (_horizontalInput > 0)
        {
            _currentDirection = Vector2.right;
            _myAnimationController.GoRight();
        }

        else if (_horizontalInput < 0)
        {
            _currentDirection = Vector2.left;
            _myAnimationController.GoLeft();
        }

        else if (_verticalInput > 0)
        {
            _currentDirection = Vector2.up;
            _myAnimationController.GoUp();
        }

        else if (_verticalInput < 0)
        {
            _currentDirection = Vector2.down;
            _myAnimationController.GoDown();
        }
    }
}
