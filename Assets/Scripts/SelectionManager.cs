using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SelectionManager", menuName = "Scriptable Objects/SelectionManager")]
public class SelectionManager : ScriptableObject
{
    public event Action<Selectable> Selected;

    public Selectable CurrentSelectable
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

    public Selectable Highlighted
    {
        get => highlighted;
        set
        {
            if (highlighted == value)
            {
                return;
            }
            if (highlighted != null && currentSelectable != highlighted)
            {
                highlighted.Deselect();
            }
            highlighted = value;
            if (value != null && currentSelectable != highlighted)
            {
                value.Highlight();
            }
        }
    }

    private Selectable currentSelectable;
    private Selectable highlighted;
}
