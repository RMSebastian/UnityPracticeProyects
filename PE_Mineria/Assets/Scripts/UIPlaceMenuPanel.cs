using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TerrainTools;

public class UIPlaceMenuPanel : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject content;
    [SerializeField] private UIMachineryPlacerPanel template;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }
    public void OpenPlaceMenu(ResourcesSO resources, UnityAction<MachinerySO> action)
    {
        if(content.transform.childCount > 1) for (int i = content.transform.childCount - 1; i > 0; i--) Destroy(content.transform.GetChild(i).gameObject);
        panel.SetActive(true);
        List <MachinerySO> machinery= gameManager.MachineryInventory.GetOwnedMachinery(resources);
        foreach(MachinerySO machine in machinery)
        {
            UIMachineryPlacerPanel ui = Instantiate(template, content.transform);
            ui.gameObject.SetActive(true);
            ui.Init(panel,machine, action);
        }
    }
}
