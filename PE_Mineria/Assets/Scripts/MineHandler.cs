using UnityEngine;
public class MineHandler : MonoBehaviour
{
    [SerializeField] private UIInformationPanel uiInfoPanel;
    [SerializeField] private UIResourcePanel uiResourcePanel;
    [SerializeField] private GameObject machineGO;
    [SerializeField] private GameObject platformGO;
    [SerializeField] private GameObject cameraPositionGO;
    private Collider _mineCollider;
    private Material _platformMaterial;
    private MineManager _mineManager;
    private GameManager _gameManager;
    private CameraManager _cameraManager;
    private ResourcesSO typeOfResource;
    private MachinerySO machineOnUse;
    private StructQuantity GeneratedQuantity = new StructQuantity();
    private float maxQuantity;
    private void Start()
    {
        _mineManager = GetComponentInParent<MineManager>();
        _mineManager?.AddMineManager(this);
        _gameManager = GameManager.Instance;
        _cameraManager = Camera.main.GetComponent<CameraManager>();
        _platformMaterial = platformGO.GetComponent<MeshRenderer>().material;
        _platformMaterial.color = Color.black;
        _mineCollider = GetComponent<Collider>();
        _mineCollider.enabled = false;
        machineGO.SetActive(false);
        uiResourcePanel.SetActiveResourcesMenu(false);
        uiInfoPanel.gameObject.SetActive(false);
    }
    public void InitMine(ResourcesSO resource)
    {
        _mineCollider.enabled = true;
        typeOfResource = resource;
        _platformMaterial.color = typeOfResource.Color;
    }
    public void SetMachine(MachinerySO machinery)
    {
        machineOnUse = machinery;
        machineGO.SetActive(true);
        uiInfoPanel.gameObject.SetActive(true);
        uiInfoPanel.Init(machineOnUse);
        GeneratedQuantity.Machine = machineOnUse;
        GeneratedQuantity.Resource = typeOfResource;
        maxQuantity = ((Mathf.Ceil(machineOnUse.Cost / 4)));
        if(maxQuantity <=0) maxQuantity = 250;
        uiResourcePanel.Init(maxQuantity, AddToInventory, Information, Hide, SellResources);

    }
    public void AddQuantity()
    {
        if (machineOnUse != null)
        {
            GeneratedQuantity.Quantity += machineOnUse.Resource.ExtractionPerCycle * machineOnUse.WorkForce;
            if (GeneratedQuantity.Quantity > maxQuantity) GeneratedQuantity.Quantity = maxQuantity;
            uiResourcePanel.SetSliderValue(GeneratedQuantity.Quantity);
        }
    }
    public void OnSelectEvent()
    {
        if (machineOnUse == null) _mineManager.OnSelectEvent(typeOfResource, SetMachine);
        else
        {
            uiResourcePanel.SetActiveResourcesMenu(true);
            _cameraManager.SetCameraPosition(cameraPositionGO.transform,0.5f);
        }
    }
    public void AddToInventory()
    {
        if(GeneratedQuantity.Quantity > 0)
        {
            _gameManager.ResourcesInventory.SetNewInventory(GeneratedQuantity);
            GeneratedQuantity.Quantity = 0;
            uiResourcePanel.SetSliderValue(GeneratedQuantity.Quantity);
        }
    }
    public void SellResources()
    {
        if (GeneratedQuantity.Quantity > 0)
        {
            _gameManager.StoreManager.SellResources(GeneratedQuantity);
            GeneratedQuantity.Quantity = 0;
            uiResourcePanel.SetSliderValue(GeneratedQuantity.Quantity);
        }
        
    }
    public void Hide()
    {
        _cameraManager.SetCameraToOrigin();
        uiResourcePanel.SetActiveResourcesMenu(false);
    }
    public void Information()=> print($"Resource: {GeneratedQuantity.Resource}, ID: {GeneratedQuantity.Machine.ID}, Quantity: {GeneratedQuantity.Quantity}");
}
