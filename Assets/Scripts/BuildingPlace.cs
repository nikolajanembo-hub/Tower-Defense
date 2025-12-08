using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingPlace : ISelectable
{
    public override void Select()
    {
            GetComponent<Renderer>().material.color = Color.yellow;
    }

    public override void Deselect()
    {
      GetComponent<Renderer>().material.color = Color.white;
    }
}
