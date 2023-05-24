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
        if (_buildingNames.Count * 2 == _buildingsObject.Count)
        {
            for (int i = 0; i < _buildingNames.Count; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    string currentName = _buildingNames[i];

                    //j bizim sayac�m�zd�r. E�er saya� �ift ise eski etiketi alacak, tek ise yeni etiketini alacak
                    if (j % 2 != 0)
                    {
                        currentName += "_Yeni";
                    }
                    else
                    {
                        currentName += "_Eski";
                    }

                    //Trim methodu => �simlerdeki bo�lu�u siliyor.
                    _buildingsDictionary.Add(currentName.Trim(), _buildingsObject[i]);
                }
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