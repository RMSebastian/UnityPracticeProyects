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
    private UnityAction<MachinerySO> action;
    public void Init(GameObject parent,MachinerySO machine, UnityAction<MachinerySO> action)
    {
        this.machinery = machine;
        this.action = action;
        txtName.text = machine.Name;
        btnPick.onClick.AddListener(()=>parent.SetActive(false));
        btnPick.onClick.AddListener(() => action.Invoke(machinery));
    }
}
