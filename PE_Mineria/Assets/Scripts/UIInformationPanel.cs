using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIInformationPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtName;
    [SerializeField] private TextMeshProUGUI txtWorkers;
    [SerializeField] private TextMeshProUGUI txtWorkForce;
    [SerializeField] private TextMeshProUGUI txtCost;
    [SerializeField] private TextMeshProUGUI txtResource;
    [SerializeField] private TextMeshProUGUI txtProduction;

    public void Init(MachinerySO machine)
    {
        txtName.text = "Name: " + machine.Name;
        txtWorkers.text = "Workers: " + machine.Workers.ToString();
        txtWorkForce.text = "WorkForce: " + machine.WorkForce.ToString();
        txtCost.text = "Cost: " + machine.Cost.ToString();
        txtResource.text = "Resource: " + machine.Resource.name;
        txtProduction.text = "Production: " + machine.Resource.ExtractionPerCycle.ToString();
    }
}
