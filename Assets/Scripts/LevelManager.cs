using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelManager : MonoBehaviour
{
   [SerializeField] private SelectionManager selectionManager;
   [SerializeField] private InputActionReference mousePosition;
   [SerializeField] private InputActionReference mouseClick;
   [SerializeField] private Transform endPoint;
   [SerializeField] private Transform startPoint;
   [SerializeField] private LevelTarget levelTarget;
   [SerializeField] private Inventory inventory;
   [SerializeField]private int startingCoins;
   [SerializeField] private LayerMask layerMask;
   
   private void OnEnable()
   {
      mouseClick.action.performed += OnClick;
   }

   private void OnClick(InputAction.CallbackContext obj)
   {
      Vector2 mousePos = mousePosition.action.ReadValue<Vector2>();
      Ray mouseRay = Camera.main.ScreenPointToRay(mousePos);
      RaycastHit hit;
      if (Physics.Raycast(mouseRay, out hit, float.MaxValue, layerMask, QueryTriggerInteraction.Ignore))
      {
         Selectable selectable = hit.collider.GetComponent<Selectable>();
         selectionManager.CurrentSelectable = selectable;
      }
   }

   private void OnDisable()
   {
      mouseClick.action.performed -= OnClick;
   }

   private void Awake()
   {
      inventory.Coins = startingCoins;
      levelTarget.targetPosition = endPoint.position;
      selectionManager.CurrentSelectable = null;
   }
}
