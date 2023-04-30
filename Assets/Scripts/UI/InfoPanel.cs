using TMPro;
using UnityEngine;

public class InfoPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
        Debug.Log("info panel aktif");

        if (Manager.Instance.GetInfoBox() == null)
        {
            Debug.Log("info box yok");
            return;
        }

        _text.text = Manager.Instance.GetInfoBox().BinaAdi + " " + Manager.Instance.GetInfoBox().BinaTarih;
    }
}