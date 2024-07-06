using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _myAnimator;

    public void AddItemToSlot()
    {
        _myAnimator.SetTrigger("Added");
    }
}
