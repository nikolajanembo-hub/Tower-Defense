using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Scriptable Objects/Inventory")]
public class Inventory : ScriptableObject
{
    private int coins;
    public int Coins
    {
        get => coins;
        set 
        {
            coins = value; 
            CoinsChanged?.Invoke();
        }
    }
    public event Action CoinsChanged;
}
