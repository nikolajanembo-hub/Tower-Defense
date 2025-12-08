using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SelectionManager", menuName = "Scriptable Objects/SelectionManager")]
public class SelectionManager : ScriptableObject
{
    public event Action<ISelectable> Selected;

    public ISelectable CurrentSelectable
    {
        get => currentSelectable;
        set
        {
            if (currentSelectable == value)
            {
                return;
            }
            if (currentSelectable != null)
            {
                currentSelectable.Deselect();
            }
            currentSelectable = value;
            if (value != null)
            {
                value.Select();
            }
            Selected?.Invoke(value);
        }
        
    }

    private ISelectable currentSelectable;
}
