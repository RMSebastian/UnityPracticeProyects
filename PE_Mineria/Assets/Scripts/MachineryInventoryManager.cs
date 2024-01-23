using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineryInventoryManager : MonoBehaviour
{
    [SerializeField] private List<MachinerySO> ownedMachinery = new List<MachinerySO>();
    
    public List<MachinerySO> GetOwnedMachinery(ResourcesSO currentResource = null)
    {
        if(currentResource == null)
        {
            return ownedMachinery;
        }
        else
        {
            List<MachinerySO> list = new List<MachinerySO>();
            foreach (MachinerySO machine in ownedMachinery)
            {
                if (machine.Resource.Color == currentResource.Color)
                {
                    list.Add(machine);
                }
            }
            return list;
        }

    }
    public void SetNewMachinery(MachinerySO newMachine)
    {
        ownedMachinery.Add(newMachine);
    }
}
