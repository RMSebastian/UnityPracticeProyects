using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MachineHandler : MonoBehaviour
{
    [SerializeField] private UIResourcePanel uiResourcePanel;
    [SerializeField] private UIInformationPanel uiInfoPanel;
    [SerializeField] private GameObject machineGO;

    private StructQuantity productionInfo = new StructQuantity();
    private void Start()
    {
        machineGO.SetActive(false);
        uiResourcePanel.SetActiveResourcesMenu(false);
        uiInfoPanel.gameObject.SetActive(false);
    }
    public void SetMachine(MachinerySO machinery)
    { 
        machineGO.SetActive(true);  
        productionInfo.Machine = machinery;
        productionInfo.SetMaxQuantity();
        uiInfoPanel.gameObject.SetActive(true);
        uiInfoPanel.Init(productionInfo.Machine);
        uiResourcePanel.Init(productionInfo,ResetQuantity);
    }
    public void AddQuantity()
    {        
        if (productionInfo.Machine != null)
        {
            productionInfo.Quantity += productionInfo.Machine.Resource.ExtractionPerCycle * productionInfo.Machine.WorkForce;
            if (productionInfo.Quantity > productionInfo.MaxQuantity) productionInfo.Quantity = productionInfo.MaxQuantity;
            uiResourcePanel.UpdateGeneratedQuantity(productionInfo);
        }
    }
    public StructQuantity ProductionInfo => productionInfo;
    public void Init(ResourcesSO resources)=> productionInfo.Resource = resources;
    public void OnSelectEvent()=> uiResourcePanel.SetActiveResourcesMenu(true);
    private void ResetQuantity() { productionInfo.Quantity = 0; uiResourcePanel.UpdateGeneratedQuantity(productionInfo); }

}
