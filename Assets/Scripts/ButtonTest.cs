using UnityEngine;

public class ButtonTest : MonoBehaviour
{
    //birden fazla ayn� tip objeye veya de�i�kene i�lem yapmak i�in kullan�lan bir koleksiyondur.
    [SerializeField] private GameObject[] _panels;

    public void PanelleriKapat()
    {
        //_panels'deki t�m game objeleri deaktive ettik.
        for (int i = 0; i < _panels.Length; i++)
        {
            _panels[i].SetActive(false);
        }
    }
}