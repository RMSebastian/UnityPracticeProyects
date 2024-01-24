using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIMachineryPlacerPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtName;
    [SerializeField] private Button btnPick;

    private MachinerySO machinery;
    public void Init(GameObject parent,MachinerySO machine, UnityAction<MachinerySO> action)
    {
        this.machinery = machine;
        txtName.text = machine.Name;
        btnPick.onClick.AddListener(() => GameManager.Instance.MachineryInventory.RemoverMachinery(machine));
        btnPick.onClick.AddListener(()=>parent.SetActive(false));
        btnPick.onClick.AddListener(() => action.Invoke(machinery));
    }
}
