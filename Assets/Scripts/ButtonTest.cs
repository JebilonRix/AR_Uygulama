using UnityEngine;

public class ButtonTest : MonoBehaviour
{
    [SerializeField] private GameObject[] _panels;

    public void PanelleriKapat()
    {
        for (int i = 0; i < _panels.Length; i++)
        {
            _panels[i].SetActive(false);
        }
    }
}