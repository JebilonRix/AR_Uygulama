using UnityEngine;

public class ARManager : MonoBehaviour
{
    [SerializeField] private string _defaultTitle = "Kapanca Sokak Kültür Rotasý";
    [SerializeField] private float _angle;
    [SerializeField] private PanelContainer _panelContainer;
    [SerializeField] private BuildingsContainer _buildingsContainer;
    [SerializeField] private InfoBoxContainer _infoBoxContainer;
    [SerializeField] private UIContainer _uiContainer;

    private GameObject _buildingNew;
    private GameObject _buildingOld;
    private bool _isBuildingNewActive = true;

    public static ARManager Instance { get; private set; }
    public InfoBox CurrentInfoBox { get; private set; }

    private void Awake()
    {
        //Singleton pattern.
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        //Tüm slider ile dönecek objeleri buluyor.
        RotateWithSlider[] rotatebles = FindObjectsOfType<RotateWithSlider>(true);

        //Ýstediðimiz açý aralýðýný tüm objelere uyguluyor.
        foreach (RotateWithSlider item in rotatebles)
        {
            item.Angle = _angle;
        }
    }

    private void Start()
    {
        //Unutma engelleme
        if (_panelContainer == null)
        {
            _panelContainer = GetComponent<PanelContainer>();
        }
        if (_buildingsContainer == null)
        {
            _buildingsContainer = GetComponent<BuildingsContainer>();
        }
        if (_infoBoxContainer == null)
        {
            _infoBoxContainer = GetComponent<InfoBoxContainer>();
        }
        if (_uiContainer == null)
        {
            _uiContainer = GetComponent<UIContainer>();
        }

        //Ana paneli açýyor.
        SetActiveOnlyOnePanel("Main");

        //Varsayýlan baþlýðý baþlýða yazýyor.
        SetTitleToDefault();

        //Bug önlemek: için infobox'a envanter 4'ü uyguluyor.
        CurrentInfoBox = _infoBoxContainer.GetInfoBox("EnvanterNo04");
    }

    //Buttonlar için
    public void SetActiveOnlyOnePanel(string panelName)
    {
        _panelContainer.ActivateOnlyOnePanel(panelName);
    }

    //Buttonlar için
    public void SetActivePanel(string panelName)
    {
        _panelContainer.ActivatePanel(panelName);
    }

    //Buttonlar için
    public void SetActiveBuilding(string buildingName)
    {
        string newName = buildingName + "_Yeni";
        string oldName = buildingName + "_Eski";

        _buildingNew = _buildingsContainer.GetObject(newName.Trim());
        _buildingOld = _buildingsContainer.GetObject(oldName.Trim());
    }

    public void DeactivateAllBuildings()
    {
        _buildingsContainer.CloseAllBuildings();
    }

    public void SwitchBuilding()
    {
        //dogruysa yanlýþ, yanlýþsa doðru yapýyor.
        _isBuildingNewActive = !_isBuildingNewActive;

        if (_isBuildingNewActive)
        {
            _buildingNew.SetActive(true);
            _buildingOld.SetActive(false);
        }
        else
        {
            _buildingNew.SetActive(false);
            _buildingOld.SetActive(true);
        }
    }

    //Buttonlar için
    public void SetActivateInfoBox(string infoBoxName)
    {
        CurrentInfoBox = _infoBoxContainer.GetInfoBox(infoBoxName);
    }

    //dokunma baþladý
    public void SetTitleText(string buildingName)
    {
        _uiContainer.SetTitleText(buildingName);
    }

    //dokunma bitti
    public void SetTitleToDefault()
    {
        _uiContainer.SetTitleText(_defaultTitle);
    }

    public void SetInfoText()
    {
        _uiContainer.SetInfoText(CurrentInfoBox);
    }

    public void SetImages()
    {
        _uiContainer.SetImages(CurrentInfoBox);
    }

    public void SetBuildingInfoMaterial()
    {
        _uiContainer.SetBuildingInfo(CurrentInfoBox);
    }
}