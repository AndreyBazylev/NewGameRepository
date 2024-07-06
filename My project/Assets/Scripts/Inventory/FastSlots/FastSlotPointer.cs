using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastSlotPointer : MonoBehaviour
{
    public void MoveMe(FastSlot fastSlot)
    {
        transform.position = fastSlot.gameObject.transform.position;
    }
}
