using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
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
   
   private PointerEventData pointer = new PointerEventData(EventSystem.current);
   private List<RaycastResult> results = new List<RaycastResult>();
   
   private void OnEnable()
   {
      mouseClick.action.performed += OnClick;
   }

   private void Update()
   {
      Vector2 mousePos = mousePosition.action.ReadValue<Vector2>();
      if (!IsOverUi(mousePos))
      {
         Ray mouseRay = Camera.main.ScreenPointToRay(mousePos);
         RaycastHit hit;
         if (Physics.Raycast(mouseRay, out hit, float.MaxValue, layerMask, QueryTriggerInteraction.Ignore))
         {
            Selectable selectable = hit.collider.GetComponent<Selectable>();
            selectionManager.Highlighted = selectable;
         }
      }
   }

   private void OnClick(InputAction.CallbackContext obj)
   {
      Vector2 mousePos = mousePosition.action.ReadValue<Vector2>();
      if (IsOverUi(mousePos))
      {
         return;
      }

      
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
   public bool IsOverUi(Vector2 position)
   {
      pointer.position = position;
      results.Clear();
      EventSystem.current.RaycastAll(pointer, results);
      return results.Count > 0;
   }
}
