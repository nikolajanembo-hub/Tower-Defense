using System;
using UnityEngine;
using UnityEngine.UI;

public class BuildingButton : MonoBehaviour
{
   [SerializeField] private Tower tower;
   [SerializeField] private SelectionManager selectionManager;
   [SerializeField] private Button selectButton;
   [SerializeField] private Inventory inventory;
   [SerializeField] private TMPro.TextMeshProUGUI text;

   private void Build()
   {
      if (tower.Price > inventory.Coins)
      {
         return;
      }
      Instantiate(tower, selectionManager.CurrentSelectable.transform.position, Quaternion.identity);
      Destroy(selectionManager.CurrentSelectable.gameObject);
      selectionManager.CurrentSelectable = null;
      inventory.Coins -= tower.Price;
   }

   private void Start()
   {
      selectButton.onClick.AddListener(Build);
      text.text = $"{tower.Name} ({tower.Price} gold)";
   }

   private void OnDestroy()
   {
      selectButton.onClick.RemoveListener(Build);
   }
}
