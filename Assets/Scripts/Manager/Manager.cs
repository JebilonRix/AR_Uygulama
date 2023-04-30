using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [Header("Arka Plan")]
    [SerializeField] private Image _background;

    [Header("Paneller")]
    [SerializeField] private GameObject _panel_selection;
    [SerializeField] private GameObject _panel_info;

    [Header("Binalar")]
    [SerializeField] private GameObject _cube;

    private InfoBox _currentInfoBox;

    public static Manager Instance { get; private set; }

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
        ActivateSelectionPanel();

        _cube.SetActive(false);
    }

    public void SetInfoBox(InfoBox infoBox)
    {
        Debug.Log("info box setlendi");

        _currentInfoBox = infoBox;
    }

    public InfoBox GetInfoBox()
    {
        return _currentInfoBox;
    }

    public void ActivateInfoPanel()
    {
        _panel_info.SetActive(true);
    }

    public void ActivateSelectionPanel()
    {
        _background.enabled = true;
        _panel_selection.SetActive(true);
        _panel_info.SetActive(false);
    }

    public void ActivateCube()
    {
        //panelleri kapat
        _panel_selection.SetActive(false);
        _panel_info.SetActive(false);

        _background.enabled = false;

        //küpü aç
        _cube.SetActive(true);
    }
}