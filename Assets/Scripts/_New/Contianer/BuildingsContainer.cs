using System.Collections.Generic;
using UnityEngine;

public class BuildingsContainer : MonoBehaviour
{
    [SerializeField] private List<string> _buildingNames = new();
    [SerializeField] private List<GameObject> _buildingsObject = new();
    private readonly Dictionary<string, GameObject> _buildingsDictionary = new();

    private void Awake()
    {
        foreach (string name in _buildingNames)
        {
            if (string.IsNullOrEmpty(name))
            {
                Debug.Log("�sim hanesi bo�");
                return;
            }
        }

        foreach (GameObject building in _buildingsObject)
        {
            if (building == null)
            {
                Debug.Log("obje yok");
                return;
            }
        }

        //isimler ile objeleri s�zl��e kaydediyor.
        if (_buildingNames.Count == _buildingsObject.Count)
        {
            for (int i = 0; i < _buildingNames.Count; i++)
            {
                _buildingsDictionary.Add(_buildingNames[i], _buildingsObject[i]);
            }
        }
        else
        {
            Debug.Log("Bina isimleri ile bina objelerinin say�s� ayn� de�il.");
        }

        CloseAll();
    }

    public GameObject GetObject(string name)
    {
        //t�m bina objeleri kapat
        CloseAll();

        //bina s�zl���nden istenilen objeyi alacak.
        _buildingsDictionary.TryGetValue(name, out GameObject obj);

        //al�nan objeyi aktive edecek.
        obj.SetActive(true);

        return obj;
    }

    private void CloseAll()
    {
        foreach (GameObject obj in _buildingsObject)
        {
            obj.SetActive(false);
        }
    }
}