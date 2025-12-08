using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelManager : MonoBehaviour
{
   [SerializeField] private SelectionManager selectionManager;
   [SerializeField] private InputActionReference mousePosition;
   [SerializeField] private InputActionReference mouseClick;

   private void OnEnable()
   {
      mouseClick.action.performed += OnClick;
   }

   private void OnClick(InputAction.CallbackContext obj)
   {
      Vector2 mousePos = mousePosition.action.ReadValue<Vector2>();
      Ray mouseRay = Camera.main.ScreenPointToRay(mousePos);
      RaycastHit hit;
      if (Physics.Raycast(mouseRay, out hit))
      {
         ISelectable selectable = hit.collider.GetComponent<ISelectable>();
         selectionManager.CurrentSelectable = selectable;
      }
   }

   private void OnDisable()
   {
      mouseClick.action.performed -= OnClick;
   }

   private void Awake()
   {
      selectionManager.CurrentSelectable = null;
   }
}
