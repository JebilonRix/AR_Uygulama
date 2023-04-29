using UnityEngine;

public class ButtonTest : MonoBehaviour
{
    //birden fazla ayný tip objeye veya deðiþkene iþlem yapmak için kullanýlan bir koleksiyondur.
    [SerializeField] private GameObject[] _panels;

    public void PanelleriKapat()
    {
        //_panels'deki tüm game objeleri deaktive ettik.
        for (int i = 0; i < _panels.Length; i++)
        {
            _panels[i].SetActive(false);
        }
    }
}