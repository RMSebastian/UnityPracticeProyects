using UnityEngine;

[CreateAssetMenu(fileName = "NewResource", menuName = "ScriptableObjects/Resource")]
public class ResourcesSO : ScriptableObject
{
    [Header("Resource Data")]
    public string Name;
    public Color Color;
    public int ExtractionPerCycle;
}
