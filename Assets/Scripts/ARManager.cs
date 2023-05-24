using UnityEngine;

public class ARManager : MonoBehaviour
{
    [SerializeField] private string _defaultTitle = "Kapanca Sokak K�lt�r Rotas�";

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
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
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

        SetTitleToDefault();

        SetActiveOnlyOnePanel("Main");

        CurrentInfoBox = _infoBoxContainer.GetInfoBox("EnvanterNo04");
    }

    //Buttonlar i�in
    public void SetActiveOnlyOnePanel(string panelName)
    {
        _panelContainer.ActivateOnlyOnePanel(panelName);
    }

    //Buttonlar i�in
    public void SetActivePanel(string panelName)
    {
        _panelContainer.ActivatePanel(panelName);
    }

    //Buttonlar i�in
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
        //dogruysa yanl��, yanl��sa do�ru yap�yor.
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

    //Buttonlar i�in
    public void SetActivateInfoBox(string infoBoxName)
    {
        CurrentInfoBox = _infoBoxContainer.GetInfoBox(infoBoxName);
    }

    //dokunma ba�lad�
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
}