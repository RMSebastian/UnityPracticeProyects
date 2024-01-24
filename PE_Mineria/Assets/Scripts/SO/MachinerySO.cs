using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMachine", menuName = "ScriptableObjects/Machine")]
public class MachinerySO : ScriptableObject
{
    [Header("Machine Data")]
    public int ID;
    public string Name;
    public int Workers;
    public float WorkForce;
    [Header("Type of Resource")]
    public ResourcesSO Resource;
    [Header("Value on Market")]
    public int Cost;
}