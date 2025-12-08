using System;
using UnityEngine;
using UnityEngine.UI;

public class BuildingButton : MonoBehaviour
{
   [SerializeField] private GameObject tower;
   [SerializeField] private SelectionManager selectionManager;
   [SerializeField] private Button selectButton;


   private void Build()
   {
      Instantiate(tower, selectionManager.CurrentSelectable.transform.position, Quaternion.identity);
      Destroy(selectionManager.CurrentSelectable.gameObject);
      selectionManager.CurrentSelectable = null;
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
