using TMPro;
using UnityEngine;

public class ARPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _buildingNameText;
    [SerializeField] private TextMeshProUGUI _buildingDiscriptionText;

    public void GetInfoFromInfoBox(InfoBox infoBox)
    {
        //Binanýn adýný text alýnýna iþliyoruz
        _buildingNameText.text = infoBox.BinaAdi;

        //Binanýn açýklamasýný text alýnýna iþliyoruz
        _buildingDiscriptionText.text = infoBox.BinaAciklama;
    }
}