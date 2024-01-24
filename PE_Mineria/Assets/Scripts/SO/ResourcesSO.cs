using UnityEngine;

[CreateAssetMenu(fileName = "NewResource", menuName = "ScriptableObjects/Resource")]
public class ResourcesSO : ScriptableObject
{
    [Header("Resource Data")]
    public string Name;
    public Color Color;
    public int ExtractionPerCycle;

    [Header("Value on Market")]
    public int initialPrice;
    public int currentPrice;
}
