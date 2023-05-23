using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class InfoPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textArea;
    [SerializeField] private Image _mainImage;
    [SerializeField] private List<Image> _images = new();
    [SerializeField] private VideoPlayer _videoPlayer;

    public void GetInfoFromInfoBox(InfoBox infoBox)
    {
        // Metin verilerini iþle
        SetText(infoBox);

        // Resim verilerini iþle
        SetImages(infoBox);

        if (infoBox.Videoclip != null)
        {
            // Video iþleme
            _videoPlayer.clip = infoBox.Videoclip;
        }
    }

    private void SetText(InfoBox infoBox)
    {
        string yazi =
            $"Adý: {infoBox.BinaAdi}\n" +
            $"Yapým Tarihi: {infoBox.BinaTarih}\n" +
            $"Restorasyon Tarihi: {infoBox.BinaRestorasyonTarihi}\n" +
            $"Yapým Sistemi: {infoBox.BinaYapimSistemi}\n" +
            $"Açýklama: {infoBox.BinaAciklama}";

        _textArea.text = yazi;
    }

    private void SetImages(InfoBox infoBox)
    {
        int lengthOfImages = infoBox.BinaResimler.Length;
        int numberOfImageObjects = _images.Count;

        // Öncelikle tüm resim nesnelerini etkinleþtirin çünkü iþleyeceðimiz resim sayýsý, aktif olan resim nesnelerinden fazla olabilir.
        for (int i = 0; i < numberOfImageObjects; i++)
        {
            _images[i].gameObject.SetActive(true);
        }

        // Her bir resmi, resim nesnelerine atýyoruz.
        for (int i = 0; i < lengthOfImages; i++)
        {
            // _images[i].sprite = infoBox.BinaResimler[i];
        }

        // Ana resim olarak, InfoBox'a eklenen ilk resmi getiriyor.
        // _mainImage.sprite = infoBox.BinaResimler[0];

        // Gerekli olmayan tüm resim nesnelerini devre dýþý býrakýyoruz.
        for (int i = lengthOfImages; i < numberOfImageObjects; i++)
        {
            _images[i].gameObject.SetActive(false);
        }
    }
}