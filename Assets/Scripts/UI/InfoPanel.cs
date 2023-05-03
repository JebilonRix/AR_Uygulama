using TMPro;
using UnityEngine;

public class InfoPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
        Debug.Log("info panel aktif");

        if (Manager.Instance.CurrentInfoBox == null)
        {
            Debug.Log("info box yok");
            return;
        }

        _text.text = Manager.Instance.CurrentInfoBox.BinaAdi + " " + Manager.Instance.CurrentInfoBox.BinaTarih;
    }
}