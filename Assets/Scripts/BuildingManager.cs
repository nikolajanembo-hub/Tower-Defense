using System;
using Unity.VisualScripting;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    [SerializeField] private GameObject buildingPanel;
    [SerializeField] private SelectionManager selectionManager;

    private void OnEnable()
    {
        buildingPanel.SetActive(selectionManager.CurrentSelectable != null);
        selectionManager.Selected += OnSelected;
    }

    private void OnDisable()
    {
        selectionManager.Selected -= OnSelected;
    }

    private void OnSelected(ISelectable selectable)
    {
        buildingPanel.SetActive(selectable != null);
    }
    
}
