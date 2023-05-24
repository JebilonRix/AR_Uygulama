using System.Collections.Generic;
using UnityEngine;

public class InfoBoxContainer : MonoBehaviour
{
    [SerializeField] private List<InfoBox> _infoBoxes = new();

    private readonly Dictionary<string, InfoBox> _infoBoxDictionary = new();

    private void Awake()
    {
        foreach (InfoBox infoBox in _infoBoxes)
        {
            _infoBoxDictionary.Add(infoBox.BinaAdi, infoBox);
        }
    }

    public InfoBox GetInfoBox(string name)
    {
        _infoBoxDictionary.TryGetValue(name, out InfoBox infoBox);

        return infoBox;
    }
}