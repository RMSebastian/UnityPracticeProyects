using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIResourcePanel : MonoBehaviour
{
    [SerializeField] private GameObject cameraPositionGO;

    [Header("UI")]
    [SerializeField] private GameObject resourcecsMenu;
    [SerializeField] private Button btnSellResources;
    [SerializeField] private Button btnAddToInventory;
    [SerializeField] private Button btnInformation;
    [SerializeField] private Button btnHide;
    [SerializeField] private Slider sldQuantityValue;

    private CameraManager _cameraManager;
    private GameManager _gameManager;
    private StructQuantity productionInfo;

    private UnityAction action;
    private void Awake()
    {
        _cameraManager = Camera.main.GetComponent<CameraManager>();
    }
    public void Init(StructQuantity productionInfo, UnityAction action)
    {
        _gameManager = GameManager.Instance;
        this.productionInfo = productionInfo;
        sldQuantityValue.maxValue = productionInfo.MaxQuantity;
        btnAddToInventory.onClick.AddListener(AddToInventory);
        btnInformation.onClick.AddListener(Information);
        btnHide.onClick.AddListener(Hide);
        btnSellResources.onClick.AddListener(SellResources);
        this.action = action;
    }
    public void SetActiveResourcesMenu(bool active)
    {
        if (active) _cameraManager.SetCameraPosition(cameraPositionGO.transform, 0.5f);
        else _cameraManager.SetCameraToOrigin();
        resourcecsMenu.SetActive(active);
    }
    public void AddToInventory()
    {
        if (productionInfo.Quantity <= 0) return;
        _gameManager.ResourcesInventory.SetNewInventory(productionInfo);
        ResetQuantity();
    }
    public void SellResources()
    {
        if (productionInfo.Quantity <= 0) return;
        _gameManager.StoreManager.SellResources(productionInfo);
        ResetQuantity();

    }
    public void Hide() => SetActiveResourcesMenu(false);
    public void Information() => print($"Resource: {productionInfo.Resource}, ID: {productionInfo.Machine.ID}, Quantity: {productionInfo.Quantity}");
    private void ResetQuantity() { action.Invoke(); }
    public void UpdateGeneratedQuantity(StructQuantity productionInfo) { this.productionInfo = productionInfo; SetSliderValue(productionInfo.Quantity); }
    public void SetSliderValue(float value) => sldQuantityValue.value = value;
}
