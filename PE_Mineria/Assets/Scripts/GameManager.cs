using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    [SerializeField] private MachineryInventoryManager machineryInventory;
    [SerializeField] private ResourceInventoryManager resourcesInventory;

    private void Awake()
    {
        if(_instance == null) _instance = this;
        else DestroyImmediate(this);
    }

    public static GameManager Instance => _instance;
    public MachineryInventoryManager MachineryInventory => machineryInventory;
    public ResourceInventoryManager ResourcesInventory => resourcesInventory;
}
