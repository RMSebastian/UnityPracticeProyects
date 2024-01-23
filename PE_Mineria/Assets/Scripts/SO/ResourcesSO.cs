using UnityEngine;

[CreateAssetMenu(fileName = "NewResource", menuName = "ScriptableObjects/Resource")]
public class ResourcesSO : ScriptableObject
{
    public string Name;
    public Color Color;
    public int ExtractionPerCycle;
}
