using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerUpgradeButton : MonoBehaviour
{
    [SerializeField] private SelectionManager selectionManager;
    [SerializeField] private Button upgradeButton;
    [SerializeField] private TextMeshProUGUI towerLevel;
    [SerializeField] private Inventory inventory;


    private void Upgrade()
    {
        if (selectionManager.CurrentSelectable is not Tower tower)
        {
            return;
        }
        if (tower.Stats.GetStat(tower.Level + 1).cost > inventory.Coins)
        {
            return;
        }
        tower.Upgrade();
        inventory.Coins -= tower.Price;
        towerLevel.SetText("Upgrade to level " + (tower.Level + 2));
    }

    private void OnEnable()
    {
        if (selectionManager.CurrentSelectable is Tower tower)
        {
            towerLevel.SetText("Upgrade to level " + (tower.Level + 2));
        }
    }

    private void Start()
    {
        selectionManager.Selected += ButtonText;
        upgradeButton.onClick.AddListener(Upgrade);
    }

    private void OnDestroy()
    {
        selectionManager.Selected -= ButtonText;
        upgradeButton.onClick.RemoveListener(Upgrade);
    }

    private void ButtonText(Selectable selectable)
    {
        if (selectionManager.CurrentSelectable is Tower tower)
        {
            towerLevel.SetText("Upgrade to level " + (tower.Level + 2));
        }
    }
}
