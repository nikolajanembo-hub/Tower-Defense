using System;
using TMPro;
using UnityEngine;

public class InventoryShow : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI coins;
   [SerializeField] private Inventory inventory;
   
   private void OnEnable()
   {
      inventory.CoinsChanged += OnCoinsChanged;
      OnCoinsChanged();
   }

   private void OnDisable()
   {
      inventory.CoinsChanged -= OnCoinsChanged;
   }

   private void OnCoinsChanged()
   {
      coins.text = "Coins " + inventory.Coins.ToString();
   }
}
