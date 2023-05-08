using RedPanda;
using System.Collections.Generic;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class Manager : MonoBehaviour
{
    [Header("Arka Plan")]
    [SerializeField] private Image _background;

    [Header("Paneller")]
    [SerializeField] private GameObject _panel_selection;
    [SerializeField] private GameObject _panel_selection_textArea;
    [SerializeField] private GameObject _panel_info;
    [SerializeField] private GameObject _panel_ar;

    [Header("Binalar")]
    [SerializeField] private GameObject _cube;
    [SerializeField] private GameObject _cube2;

    private readonly List<GameObject> _buildings = new();

    [SerializeField] private Lines<string, GameObject> _lines;

    public static Manager Instance { get; private set; }
    public InfoBox CurrentInfoBox { get; set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        _buildings.Add(_cube);
        _buildings.Add(_cube2);

        //ilk paneli aktive edecek.
        ActivatePanel(0);

        //koleksiyon index'i 0'dan baþlar. -1 olmadýðý için tüm binalarýn gameobjectleri deaktive edecek.
        ActivateBuilding(-1);
    }

    public void ActivateBuilding(int index)
    {
        //küpü aç
        for (int i = 0; i < _buildings.Count; i++)
        {
            if (index == i)
            {
                _buildings[i].SetActive(true);
            }
            else
            {
                _buildings[i].SetActive(false);
            }
        }

        if (index != -1)
        {
            //ar panelini açmak için.
            ActivatePanel(2);
        }
    }

    //Button
    public void ActivatePanel(int index)
    {
        //0. index -> ana harita,
        //1. index -> yan panel
        //2. panel -> ar panel

        if (index == 0)
        {
            SetPanelsActivation(true, true, false, false, true);
        }
        else if (index == 1)
        {
            SetPanelsActivation(true, false, true, false, true);

            _panel_info.GetComponent<InfoPanel>().GetInfoFromInfoBox(CurrentInfoBox);
        }
        else if (index == 2)
        {
            //2. index'im benim ar panelim. AR panelinde background'a ihtiyaç yok.
            SetPanelsActivation(false, false, false, true, false);

            _panel_ar.GetComponent<ARPanel>().GetInfoFromInfoBox(CurrentInfoBox);
        }
    }

    private void SetPanelsActivation(bool selection, bool selectionTextArea, bool info, bool ar, bool background)
    {
        _panel_selection.SetActive(selection);
        _panel_selection_textArea.SetActive(selectionTextArea);
        _panel_info.SetActive(info);
        _panel_ar.SetActive(ar);

        _background.enabled = background;
    }
}