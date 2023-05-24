using System.Collections.Generic;
using UnityEngine;

public class PanelContainer : MonoBehaviour
{
    [SerializeField] private List<string> _panelNames = new();
    [SerializeField] private List<GameObject> _panelObject = new();
    private readonly Dictionary<string, GameObject> _panelDictionary = new();

    private void Awake()
    {
        foreach (string name in _panelNames)
        {
            if (string.IsNullOrEmpty(name))
            {
                Debug.Log("Ýsim hanesi boþ");
                return;
            }
        }

        foreach (GameObject building in _panelObject)
        {
            if (building == null)
            {
                Debug.Log("obje yok");
                return;
            }
        }

        //isimler ile objeleri sözlüðe kaydediyor.
        if (_panelNames.Count == _panelObject.Count)
        {
            for (int i = 0; i < _panelNames.Count; i++)
            {
                _panelDictionary.Add(_panelNames[i], _panelObject[i]);
            }
        }
        else
        {
            Debug.Log("Bina isimleri ile bina objelerinin sayýsý ayný deðil.");
        }

        CloseAll();
    }

    public GameObject ActivateOnlyOnePanel(string panelName)
    {
        //tüm panel objeleri kapat
        CloseAll();

        return ActivatePanel(panelName);
    }

    public GameObject ActivatePanel(string panelName)
    {
        //panel sözlüðünden istenilen objeyi alacak.
        _panelDictionary.TryGetValue(panelName, out GameObject obj);

        //alýnan objeyi aktive edecek.
        obj.SetActive(true);

        return obj;
    }

    private void CloseAll()
    {
        foreach (GameObject obj in _panelObject)
        {
            obj.SetActive(false);
        }
    }
}