using System.Collections.Generic;
using UnityEngine;

public class BuildingsContainer : MonoBehaviour
{
    [SerializeField] private List<string> _buildingNames = new();

    [TextArea]
    [SerializeField] private string note = "Öncelikle binanýn eski halini ekleyin daha sonra yeni halini ekleyin. Yani bir eski, bir yeni þeklinde olmalýdýr.";
    [Space(5)]
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
        int j = 0;

        for (int i = 0; i < _buildingsObject.Count; i++)
        {
            string currentName = _buildingNames[j];

            //j bizim sayacýmýzdýr. Eðer sayaç çift ise eski etiketi alacak, tek ise yeni etiketini alacak
            if (i % 2 != 0)
            {
                currentName += "_Eski";
                j++;
            }
            else
            {
                currentName += "_Yeni";
            }

            //Trim methodu => Ýsimlerdeki boþluðu siliyor.
            _buildingsDictionary.Add(currentName.Trim(), _buildingsObject[i]);
        }

        CloseAllBuildings();
    }

    public GameObject GetObject(string name)
    {
        //tüm bina objeleri kapat
        CloseAllBuildings();

        //bina sözlüðünden istenilen objeyi alacak.
        _buildingsDictionary.TryGetValue(name, out GameObject obj);

        //alýnan objeyi aktive edecek.
        obj.SetActive(true);

        return obj;
    }

    public void CloseAllBuildings()
    {
        foreach (GameObject obj in _buildingsObject)
        {
            obj.SetActive(false);
        }
    }
}