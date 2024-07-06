using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInHand : MonoBehaviour
{
    public int MyID;

    [SerializeField] private Sprite _myIcon;
    [SerializeField] private string _myName;
    [SerializeField] private string _myDescription;
    [SerializeField] private int _myCount;

    private void Start()
    {
        if (_myName == "")
            _myName = gameObject.name;

        if (_myDescription == "")
            _myDescription = string.Empty;

        if (_myIcon)
            _myIcon = gameObject.GetComponent<SpriteRenderer>().sprite;
    }

    public virtual void UseByRightClick(PlayerContoller player)
    { }

    public virtual void UseByLeftClick(PlayerContoller player)
    { }
}
