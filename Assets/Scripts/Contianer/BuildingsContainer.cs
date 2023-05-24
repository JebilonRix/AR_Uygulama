using System.Collections.Generic;
using UnityEngine;

public class BuildingsContainer : MonoBehaviour
{
    [SerializeField] private List<string> _buildingNames = new();

    [TextArea]
    [SerializeField] private string note = "�ncelikle binan�n eski halini ekleyin daha sonra yeni halini ekleyin. Yani bir eski, bir yeni �eklinde olmal�d�r.";
    [Space(5)]
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
        int j = 0;

        for (int i = 0; i < _buildingsObject.Count; i++)
        {
            string currentName = _buildingNames[j];

            //j bizim sayac�m�zd�r. E�er saya� �ift ise eski etiketi alacak, tek ise yeni etiketini alacak
            if (i % 2 != 0)
            {
                currentName += "_Eski";
                j++;
            }
            else
            {
                currentName += "_Yeni";
            }

            //Trim methodu => �simlerdeki bo�lu�u siliyor.
            _buildingsDictionary.Add(currentName.Trim(), _buildingsObject[i]);
        }

        CloseAllBuildings();
    }

    public GameObject GetObject(string name)
    {
        //t�m bina objeleri kapat
        CloseAllBuildings();

        //bina s�zl���nden istenilen objeyi alacak.
        _buildingsDictionary.TryGetValue(name, out GameObject obj);

        //al�nan objeyi aktive edecek.
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