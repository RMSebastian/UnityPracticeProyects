using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceInventoryManager : MonoBehaviour
{
    private List<StructQuantity> inventory = new List<StructQuantity>();

    public void SetNewInventory(StructQuantity newInventory)
    {
        inventory.Add(newInventory);
    }

    public List<StructQuantity> Inventory => inventory;
}
