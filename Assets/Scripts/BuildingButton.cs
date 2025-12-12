using System;
using UnityEngine;
using UnityEngine.UI;

public class BuildingButton : MonoBehaviour
{
   [SerializeField] private Tower tower;
   [SerializeField] private SelectionManager selectionManager;
   [SerializeField] private Button selectButton;
   [SerializeField] private Inventory inventory;


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
   }

   private void OnDestroy()
   {
      selectButton.onClick.RemoveListener(Build);
   }
}
