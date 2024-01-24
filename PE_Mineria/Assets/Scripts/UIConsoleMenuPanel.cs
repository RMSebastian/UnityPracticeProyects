using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIConsoleMenuPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtOpenConsole;
    [SerializeField] private TextMeshProUGUI txtTemplate;
    [SerializeField] private TMP_InputField xntDebugField;
    [SerializeField] private GameObject pnlConsoleMenu;
    [SerializeField] private GameObject pnlContent;
    [SerializeField] private Button btnOpenConsole;
    [SerializeField] private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }
    private void InitialConfiguration(bool active)
    {
        if (active)
        {
            OnEndEdit("> info inventory (shows resources in inventory)");
            OnEndEdit("> info machinery (shows owned machinery)");
            OnEndEdit("> info buy (shows machinery and prices)");
            OnEndEdit("> buy[id] (Buys machinery)");
        }
        else if(pnlContent.transform.childCount > 1) for (int i = pnlContent.transform.childCount - 1; i > 0; i--) Destroy(pnlContent.transform.GetChild(i).gameObject);

    }
    public void OpenConsole(bool active)
    {
        pnlConsoleMenu.SetActive(active);
        txtOpenConsole.text = (active) ?"Close Console":"Open Console";
        InitialConfiguration(active);
        btnOpenConsole.onClick.RemoveAllListeners();
        btnOpenConsole.onClick.AddListener(() => OpenConsole(!active));
    }
    public void OnEndEdit(string value)
    {
        int buyIndex = -1;
        if (value.Contains("buy["))
        {
            int index = value.IndexOf("[");
            if(index + 1 != 0)
            {
                string number = value.Substring(index + 1);
                char character = number.ToCharArray()[0];
                if (char.IsDigit(character)) {buyIndex = (int)char.GetNumericValue(character); value = value.Remove(index+1, 1); }
            }
        }
        switch (value)
        {
            case "info inventory":
                List<StructQuantity> inventory = gameManager.ResourcesInventory.Inventory;
                if (inventory.Count <= 0) OnEndEdit("There is no Store list");
                else OnEndEdit("ID|Name|Resource|Cost|Workers|WorkForce");
                for (int i = 0; i <= inventory.Count-1; i++)OnEndEdit($"{inventory[i].Machine.ID}|{inventory[i].Machine.Name}|{inventory[i].Resource.Name}|{inventory[i].Machine.Cost}|{inventory[i].Machine.Workers}|{inventory[i].Machine.WorkForce}");
                break;
            case "info machinery":
                List<MachinerySO> ownedMachinery = gameManager.MachineryInventory.Machinery;
                if (ownedMachinery.Count <= 0) OnEndEdit("There is no Store list");
                else OnEndEdit("ID|Name|Resource|Cost|Workers|WorkForce");
                for (int i = 0; i <= ownedMachinery.Count - 1; i++)OnEndEdit($"{ownedMachinery[i].ID}|{ownedMachinery[i].Name}|{ownedMachinery[i].Resource.Name}|{ownedMachinery[i].Cost}|{ownedMachinery[i].Workers}|{ownedMachinery[i].WorkForce}");
                break;
            case "info buy":
                List<MachinerySO> storeMachinery = gameManager.StoreManager.Machineries;
                if(storeMachinery.Count <= 0) OnEndEdit("There is no Store list");
                else OnEndEdit("ID|Name|Resource|Cost|Workers|WorkForce");
                for (int i = 0; i <= storeMachinery.Count - 1; i++)OnEndEdit($"{storeMachinery[i].ID}|{storeMachinery[i].Name}|{storeMachinery[i].Resource.Name}|{storeMachinery[i].Cost}|{storeMachinery[i].Workers}|{storeMachinery[i].WorkForce}");
                break;
            case "buy[]":
                if(buyIndex == -1){OnEndEdit("purchased failed"); break;}
                List<MachinerySO> seenMachinery = gameManager.StoreManager.Machineries;
                if (buyIndex <= seenMachinery.Count - 1 && seenMachinery[buyIndex].Cost <= WalletManager.Money) { gameManager.StoreManager.BuyMachinery(seenMachinery[buyIndex]); OnEndEdit("Purchase completed"); }
                else OnEndEdit("Not enough money");
                break;
            default:
                TextMeshProUGUI text = Instantiate(txtTemplate, pnlContent.transform);
                text.text = value;
                text.gameObject.SetActive(true);
                text.transform.SetSiblingIndex(1);
                break;
        }
        xntDebugField.text = "";
        
    }
}
