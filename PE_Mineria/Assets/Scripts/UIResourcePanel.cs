using UnityEngine;
using UnityEngine.UI;

public class UIResourcePanel : MonoBehaviour
{
    [SerializeField] private Button btnSellResources; //needs storeManager
    [SerializeField] private Button btnAddToInventory; //needs ResourcesManger, struct with data of the quantity
    [SerializeField] private Button btnInformation; //needs an struct with data of the quantity
    [SerializeField] private Button btnHide; //needs control both on this UI and camera.Position

    public void Init()
    {
       
    }
}
