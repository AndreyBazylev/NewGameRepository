using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BuildingUIController : MonoBehaviour
{
    //[SerializeField] private List<BuildingCategory> _buildingCategories = new List<BuildingCategory>();
    //[SerializeField] private GameObject _categoriesScrollViewObject;   

    //[SerializeField] private GameObject _slotPrefab;

    //private ScrollView _categoriesSrollView;
    //private static GameObject _slotPrefabStatic;

    //private void Awake()
    //{
    //    _slotPrefabStatic = _slotPrefab;
    //    _slotPrefabStatic = _categoriesScrollViewObject.transform;
    //}

    //public static BuildingSlot CreateNewBuildingSlot()
    //{
    //    BuildingSlot newSlot = Instantiate(_slotPrefabStatic).gameObject.GetComponent<BuildingSlot>();
    //    return newSlot;
    //}

    //public void OpenCategoryAtIndex(int index)
    //{
    //    AddSlotsFromList(_buildingCategories[index].TakeMe());  
    //}

    //private void AddSlotsFromList(List<BuildingSlot> buildingSlots)
    //{
    //    foreach (var index in buildingSlots)
    //    {
    //        BuildingSlot newSlot = CreateNewBuildingSlot();
    //        newSlot.SetValues(index.ID, index.Image, index.Name, index.MyObject);
    //        _categoriesSrollView.Add(newSlot.GetComponent<VisualElement>());
    //    }
    //}
}
