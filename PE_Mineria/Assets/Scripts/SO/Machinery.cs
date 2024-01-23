using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMachine",menuName = "ScriptableObjects/Machine")]
public class MachinerySO : ScriptableObject
{
    public int ID;
    public string Name;
    public Color ResourceColor;
    public int Cost;
    public int Workers;
    public float Multiplier;

}
