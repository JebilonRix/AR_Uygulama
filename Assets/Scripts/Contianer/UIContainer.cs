using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIContainer : MonoBehaviour
{
    [SerializeField] private TextMeshPro _titleText;
    [SerializeField] private TextMeshPro _infoText;

    [SerializeField] private MeshRenderer _mainImage;
    [SerializeField] private List<MeshRenderer> _buttonImages = new();

    [SerializeField] private MeshRenderer _buildingInfo;

    public void SetTitleText(string title)
    {
        _titleText.text = title;
    }

    public void SetInfoText(InfoBox infoBox)
    {
        string yazi =
           $"Adý: {infoBox.BinaAdi}\n" +
           $"Yapým Tarihi: {infoBox.BinaTarih}\n" +
           $"Restorasyon Tarihi: {infoBox.BinaRestorasyonTarihi}\n" +
           $"Yapým Sistemi: {infoBox.BinaYapimSistemi}\n" +
           $"Açýklama: {infoBox.BinaAciklama}";

        _infoText.text = yazi;
    }

    public void SetImages(InfoBox infoBox)
    {
        int lengthOfImages = infoBox.BinaResimler.Length;
        int numberOfImageObjects = _buttonImages.Count;

        // Öncelikle tüm resim nesnelerini etkinleþtirin çünkü iþleyeceðimiz resim sayýsý, aktif olan resim nesnelerinden fazla olabilir.
        for (int i = 0; i < numberOfImageObjects; i++)
        {
            _buttonImages[i].gameObject.SetActive(true);
        }

        // Her bir resmi, resim nesnelerine atýyoruz.
        for (int i = 0; i < lengthOfImages; i++)
        {
            _buttonImages[i].material = infoBox.BinaResimler[i];
        }

        // Ana resim olarak, InfoBox'a eklenen ilk resmi getiriyor.
        _mainImage.material = infoBox.BinaResimler[0];

        // Gerekli olmayan tüm resim nesnelerini devre dýþý býrakýyoruz.
        for (int i = lengthOfImages; i < numberOfImageObjects; i++)
        {
            _buttonImages[i].gameObject.SetActive(false);
        }
    }

    public void SetBuildingInfo(InfoBox infoBox)
    {
        _buildingInfo.material = infoBox.BinaBilgiMaterial;
    }
}