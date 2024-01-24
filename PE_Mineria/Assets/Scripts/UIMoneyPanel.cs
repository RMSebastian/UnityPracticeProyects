using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIMoneyPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtMoney;

    public void Init(float money)
    {
        txtMoney.text = money.ToString();
    }
}
