using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MachineHandler))]
public class MineHandler : MonoBehaviour
{
    public GameObject platformGO;
    private MineManager _mineManager;
    private MachineHandler _machineHandler;
    private UnityAction updateAction;
    private void Start()
    {
        _machineHandler = GetComponent<MachineHandler>();
        updateAction += _machineHandler.AddQuantity;
        _mineManager = GetComponentInParent<MineManager>();
        _mineManager.AddMineManager(this);
        platformGO.GetComponent<MeshRenderer>().material.color = Color.black;
        this.GetComponent<Collider>().enabled = false;
    }
    public void InitMine(ResourcesSO resource)
    {
        this.GetComponent<Collider>().enabled = true;
        _machineHandler.Init(resource);
        platformGO.GetComponent<MeshRenderer>().material.color = resource.Color;
    }
    public void OnSelectEvent()
    {
        if (_machineHandler.ProductionInfo.Machine == null) _mineManager.OnSelectEvent(_machineHandler.ProductionInfo.Resource, _machineHandler.SetMachine);
        else _machineHandler.OnSelectEvent();
    }
    public void UpdateOnCyle() => updateAction.Invoke();
}
