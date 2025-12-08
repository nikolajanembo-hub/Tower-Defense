using UnityEngine;

public abstract class ISelectable: MonoBehaviour
{
    [SerializeField] protected SelectionManager selectionManager;
    public abstract void Select();
    public abstract void Deselect();
}
