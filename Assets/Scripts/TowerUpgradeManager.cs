using UnityEngine;

public class TowerUpgradeManager : MonoBehaviour
{
    [SerializeField] private GameObject towerPanel;
    [SerializeField] private SelectionManager selectionManager;

    private void OnEnable()
    {
        towerPanel.SetActive(selectionManager.CurrentSelectable != null && selectionManager.CurrentSelectable is Tower);
        selectionManager.Selected += OnSelected;
    }

    private void OnDisable()
    {
        selectionManager.Selected -= OnSelected;
    }

    private void OnSelected(Selectable selectable)
    {
        towerPanel.SetActive(selectable != null && selectable is Tower);
    }
}
