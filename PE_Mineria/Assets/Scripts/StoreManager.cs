using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(WalletManager))]
public class StoreManager : MonoBehaviour
{
    private WalletManager walletManager;
    private GameManager gameManager;

    [SerializeField] private UnityEvent<float> OnInteractionEvent = new UnityEvent<float>();
    private void Start()
    {
        walletManager = GetComponent<WalletManager>();
        gameManager = GameManager.Instance;
    }

    public void SellResources(StructQuantity resources)
    {
        float money = resources.Quantity;
        walletManager.AddMoney(money);
        OnInteractionEvent.Invoke(WalletManager.Money);
    }
    public void BuyMachinery(MachinerySO machinery)
    {
        gameManager.MachineryInventory.SetNewMachinery(machinery);
        walletManager.SubstractMoney(machinery.Cost);
        OnInteractionEvent.Invoke(WalletManager.Money);
    }
}
