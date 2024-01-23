using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIPlaceMenuPanel : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject content;
    [SerializeField] private UIMachineryPlacerPanel template;
    private MachineryInventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = GameManager.Instance.MachineryInventory;
    }
    public void OpenPlaceMenu(ResourcesSO resources, UnityAction<MachinerySO> action)
    {
        panel.SetActive(true);
        List <MachinerySO> machinery= inventoryManager.GetOwnedMachinery(resources);
        foreach(MachinerySO machine in machinery)
        {
            UIMachineryPlacerPanel ui = Instantiate(template, content.transform);
            ui.gameObject.SetActive(true);
            ui.Init(panel,machine, action);
        }
    }
}
