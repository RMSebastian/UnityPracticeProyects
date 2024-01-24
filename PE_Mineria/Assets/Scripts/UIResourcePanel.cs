using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIResourcePanel : MonoBehaviour
{
    [SerializeField] private GameObject resourcecsMenu;
    [SerializeField] private Button btnSellResources; //needs storeManager
    [SerializeField] private Button btnAddToInventory; //needs ResourcesManger, struct with data of the quantity
    [SerializeField] private Button btnInformation; //needs an struct with data of the quantity
    [SerializeField] private Button btnHide; //needs control both on this UI and camera.Position
    [SerializeField] private Slider sldQuantityValue;
    public void Init(float sliderMaxValue, UnityAction addToInventoryAction, UnityAction informationAction, UnityAction HideAction,UnityAction sellResourcesAction)
    {
        
        sldQuantityValue.maxValue = sliderMaxValue;
        btnAddToInventory.onClick.AddListener(addToInventoryAction);
        btnInformation.onClick.AddListener(informationAction);
        btnHide.onClick.AddListener(HideAction);
        btnSellResources.onClick.AddListener(sellResourcesAction);
    }
    public void SetSliderValue(float value) => sldQuantityValue.value = value;
    public void SetActiveResourcesMenu(bool active)=> resourcecsMenu.SetActive(active);
}
