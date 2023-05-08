using TMPro;
using UnityEngine;

public class ARPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _buildingNameText;
    [SerializeField] private TextMeshProUGUI _buildingDiscriptionText;

    public void GetInfoFromInfoBox(InfoBox infoBox)
    {
        //Binan�n ad�n� text al�n�na i�liyoruz
        _buildingNameText.text = infoBox.BinaAdi;

        //Binan�n a��klamas�n� text al�n�na i�liyoruz
        _buildingDiscriptionText.text = infoBox.BinaAciklama;
    }
}