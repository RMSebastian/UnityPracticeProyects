using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineHandler : MonoBehaviour
{
    [SerializeField] private UIInformationPanel uiInfoPanel;
    [SerializeField] private UIResourcePanel uiResourcePanel;
    [SerializeField] private GameObject machineGO;
    [SerializeField] private GameObject platformGO;
    private Collider _mineCollider;
    private Material _platformMaterial;
    private MineManager _manager;


    private ResourcesSO typeOfResource;
    private MachinerySO machineOnUse;
    private void Start()
    {
        _manager = GetComponentInParent<MineManager>();
        _manager?.AddMineManager(this);

        _platformMaterial = platformGO.GetComponent<MeshRenderer>().material;
        _platformMaterial.color = Color.black;

        _mineCollider = GetComponent<Collider>();
        _mineCollider.enabled = false;

        machineGO.SetActive(false);
    }
    public void InitMine(ResourcesSO resource)
    {
        _mineCollider.enabled = true;
        typeOfResource = resource;
        _platformMaterial.color = typeOfResource.Color;
    }
    public void SetMachine(MachinerySO machinery)
    {
        machineOnUse = machinery;
        machineGO.SetActive(true);
        uiInfoPanel.Init(machinery);
    }
    public void AddQuantity()
    {
        if (machineOnUse == null)
        {

        }
        else
        {

        }
    }
    public void OnSelectEvent()
    {
        if(machineOnUse == null) _manager.OnSelectEvent(typeOfResource, SetMachine);
        else print(machineOnUse);
        
    }

}
