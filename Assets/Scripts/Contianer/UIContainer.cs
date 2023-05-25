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
           $"Ad�: {infoBox.BinaAdi}\n" +
           $"Yap�m Tarihi: {infoBox.BinaTarih}\n" +
           $"Restorasyon Tarihi: {infoBox.BinaRestorasyonTarihi}\n" +
           $"Yap�m Sistemi: {infoBox.BinaYapimSistemi}\n" +
           $"A��klama: {infoBox.BinaAciklama}";

        _infoText.text = yazi;
    }

    public void SetImages(InfoBox infoBox)
    {
        int lengthOfImages = infoBox.BinaResimler.Length;
        int numberOfImageObjects = _buttonImages.Count;

        // �ncelikle t�m resim nesnelerini etkinle�tirin ��nk� i�leyece�imiz resim say�s�, aktif olan resim nesnelerinden fazla olabilir.
        for (int i = 0; i < numberOfImageObjects; i++)
        {
            _buttonImages[i].gameObject.SetActive(true);
        }

        // Her bir resmi, resim nesnelerine at�yoruz.
        for (int i = 0; i < lengthOfImages; i++)
        {
            _buttonImages[i].material = infoBox.BinaResimler[i];
        }

        // Ana resim olarak, InfoBox'a eklenen ilk resmi getiriyor.
        _mainImage.material = infoBox.BinaResimler[0];

        // Gerekli olmayan t�m resim nesnelerini devre d��� b�rak�yoruz.
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