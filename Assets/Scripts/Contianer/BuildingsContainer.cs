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
                Debug.Log("Ýsim hanesi boþ");
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

        //isimler ile objeleri sözlüðe kaydediyor.
        if (_buildingNames.Count * 2 == _buildingsObject.Count)
        {
            for (int i = 0; i < _buildingNames.Count; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    string currentName = _buildingNames[i];

                    //j bizim sayacýmýzdýr. Eðer sayaç çift ise eski etiketi alacak, tek ise yeni etiketini alacak
                    if (j % 2 != 0)
                    {
                        currentName += "_Yeni";
                    }
                    else
                    {
                        currentName += "_Eski";
                    }

                    //Trim methodu => Ýsimlerdeki boþluðu siliyor.
                    _buildingsDictionary.Add(currentName.Trim(), _buildingsObject[i]);
                }
            }
        }
        else
        {
            Debug.Log("Bina isimleri ile bina objelerinin sayýsý ayný deðil.");
        }

        CloseAll();
    }

    public GameObject GetObject(string name)
    {
        //tüm bina objeleri kapat
        CloseAll();

        //bina sözlüðünden istenilen objeyi alacak.
        _buildingsDictionary.TryGetValue(name, out GameObject obj);

        //alýnan objeyi aktive edecek.
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