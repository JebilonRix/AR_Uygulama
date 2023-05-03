using UnityEngine;
using Image = UnityEngine.UI.Image;

public class Manager : MonoBehaviour
{
    [SerializeField] private InfoBox _currentInfoBox;

    [Header("Arka Plan")]
    [SerializeField] private Image _background;

    [Header("Paneller")]
    [SerializeField] private GameObject _panel_selection;
    [SerializeField] private GameObject _panel_info;
    [SerializeField] private GameObject _panel_ar;

    [Header("Binalar")]
    [SerializeField] private GameObject _cube;

    public static Manager Instance { get; private set; }
    public InfoBox CurrentInfoBox { get => _currentInfoBox; private set => _currentInfoBox = value; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        ActivatePanel(0);

        _cube.SetActive(false);
    }

    public void SetInfoBox(InfoBox infoBox)
    {
        Debug.Log("info box setlendi");

        CurrentInfoBox = infoBox;
    }

    //Button
    public void ActivatePanel(int index)
    {
        //0. index -> ana harita,
        //1. index -> yan panel
        //2. panel -> ar panel
        //3. panel ana ekran

        if (index == 0)
        {
            SetPanelsActivation(true, false, false, true);
        }
        else if (index == 1)
        {
            SetPanelsActivation(true, true, false, true);
        }
        else if (index == 2)
        {
            //2. index'im benim ar panelim. AR panelinde background'a ihtiyaç yok.
            SetPanelsActivation(false, false, true, false);
        }
    }

    private void SetPanelsActivation(bool first, bool second, bool third, bool background)
    {
        _panel_selection.SetActive(first);
        _panel_info.SetActive(second);
        _panel_ar.SetActive(third);

        _background.enabled = background;
    }

    public void ActivateCube()
    {
        //küpü aç
        _cube.SetActive(true);
    }
}