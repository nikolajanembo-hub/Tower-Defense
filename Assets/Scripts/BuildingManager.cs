using System;
using Unity.VisualScripting;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    [SerializeField] private GameObject buildingPanel;
    [SerializeField] private SelectionManager selectionManager;

    private void OnEnable()
    {
        buildingPanel.SetActive(selectionManager.CurrentSelectable != null && selectionManager.CurrentSelectable is BuildingPlace);
        selectionManager.Selected += OnSelected;
    }

    private void OnDisable()
    {
        selectionManager.Selected -= OnSelected;
    }

    private void OnSelected(Selectable selectable)
    {
        buildingPanel.SetActive(selectable != null && selectable is BuildingPlace);
    }
    
}
