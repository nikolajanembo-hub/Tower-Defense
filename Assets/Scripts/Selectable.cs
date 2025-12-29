using UnityEngine;

public abstract class Selectable: MonoBehaviour
{
    [SerializeField] private float selectedWidth = .3f;
    [SerializeField] private Color selectedColor = Color.yellow;
    [SerializeField] private float highlightedWidth = .3f;
    [SerializeField] private Color highlightedColor = Color.white;
    [SerializeField] private float unselectedWidth = .3f;
    [SerializeField] private Color unselectedColor = Color.black;
    private MaterialPropertyBlock block;
    private Renderer bpRenderer;

    protected virtual void Awake()
    {
        bpRenderer = GetComponentInChildren<Renderer>();
        block = new MaterialPropertyBlock();
        Deselect();
    }

    public void Select()
    {
        bpRenderer.GetPropertyBlock(block);
        block.SetFloat("_OutlineWidth", selectedWidth);
        block.SetColor("_OutlineColor", selectedColor);
        bpRenderer.SetPropertyBlock(block);
    }

    public void Highlight()
    {
        bpRenderer.GetPropertyBlock(block);
        block.SetFloat("_OutlineWidth", highlightedWidth);
        block.SetColor("_OutlineColor", highlightedColor);
        bpRenderer.SetPropertyBlock(block);
    }

    public void Deselect()
    {
        bpRenderer.GetPropertyBlock(block);
        block.SetFloat("_OutlineWidth", unselectedWidth);
        block.SetColor("_OutlineColor", unselectedColor);
        bpRenderer.SetPropertyBlock(block);
    }
}
