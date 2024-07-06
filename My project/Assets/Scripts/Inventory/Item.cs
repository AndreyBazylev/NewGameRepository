using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class Item : UsebleItem
{
    public int MyID;

    [SerializeField] private Sprite _myIcon;
    [SerializeField] private string _myName;
    [SerializeField] private string _myDescription;

    private void Start()
    {
        if (_myName == "")
            _myName = gameObject.name;

        if (_myDescription == "")
            _myDescription = string.Empty;

        if (_myIcon)
            _myIcon = gameObject.GetComponent<SpriteRenderer>().sprite;
    }

    public override void Use(PlayerContoller player)
    {
        InventoryController.AddItemAndSetValues(PickUp(), player._myChest);
        Destroy(gameObject);
    }

    protected InventorySlot PickUp()
    {
        return new InventorySlot(MyID, _myIcon, _myName, 1);
    }
}
