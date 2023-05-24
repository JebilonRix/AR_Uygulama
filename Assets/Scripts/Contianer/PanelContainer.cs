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
                Debug.Log("�sim hanesi bo�");
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

        //isimler ile objeleri s�zl��e kaydediyor.
        if (_panelNames.Count == _panelObject.Count)
        {
            for (int i = 0; i < _panelNames.Count; i++)
            {
                _panelDictionary.Add(_panelNames[i], _panelObject[i]);
            }
        }
        else
        {
            Debug.Log("Bina isimleri ile bina objelerinin say�s� ayn� de�il.");
        }

        CloseAll();
    }

    public GameObject ActivateOnlyOnePanel(string panelName)
    {
        //t�m panel objeleri kapat
        CloseAll();

        return ActivatePanel(panelName);
    }

    public GameObject ActivatePanel(string panelName)
    {
        //panel s�zl���nden istenilen objeyi alacak.
        _panelDictionary.TryGetValue(panelName, out GameObject obj);

        //al�nan objeyi aktive edecek.
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