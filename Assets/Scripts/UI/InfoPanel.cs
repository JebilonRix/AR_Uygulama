using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _adText;
    [SerializeField] private TextMeshProUGUI _tarihText;
    [SerializeField] private Image _anaImage;

    public void GetInfoFromInfoBox(InfoBox infoBox)
    {
        Debug.Log(infoBox.BinaAdi + " veriler i�lendi");

        //yaz�sal verileri i�liyorum.
        _adText.text = infoBox.BinaAdi;
        _tarihText.text = infoBox.BinaTarih;

        //g�rsel verileri i�liyorum.
        _anaImage.sprite = infoBox.BinaAnaResmi;
    }
}