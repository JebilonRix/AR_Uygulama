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
        // Metin verilerini i�le
        SetText(infoBox);

        // Resim verilerini i�le
        SetImages(infoBox);

        if (infoBox.Videoclip != null)
        {
            // Video i�leme
            _videoPlayer.clip = infoBox.Videoclip;
        }
    }

    private void SetText(InfoBox infoBox)
    {
        string yazi =
            $"Ad�: {infoBox.BinaAdi}\n" +
            $"Yap�m Tarihi: {infoBox.BinaTarih}\n" +
            $"Restorasyon Tarihi: {infoBox.BinaRestorasyonTarihi}\n" +
            $"Yap�m Sistemi: {infoBox.BinaYapimSistemi}\n" +
            $"A��klama: {infoBox.BinaAciklama}";

        _textArea.text = yazi;
    }

    private void SetImages(InfoBox infoBox)
    {
        int lengthOfImages = infoBox.BinaResimler.Length;
        int numberOfImageObjects = _images.Count;

        // �ncelikle t�m resim nesnelerini etkinle�tirin ��nk� i�leyece�imiz resim say�s�, aktif olan resim nesnelerinden fazla olabilir.
        for (int i = 0; i < numberOfImageObjects; i++)
        {
            _images[i].gameObject.SetActive(true);
        }

        // Her bir resmi, resim nesnelerine at�yoruz.
        for (int i = 0; i < lengthOfImages; i++)
        {
            // _images[i].sprite = infoBox.BinaResimler[i];
        }

        // Ana resim olarak, InfoBox'a eklenen ilk resmi getiriyor.
        // _mainImage.sprite = infoBox.BinaResimler[0];

        // Gerekli olmayan t�m resim nesnelerini devre d��� b�rak�yoruz.
        for (int i = lengthOfImages; i < numberOfImageObjects; i++)
        {
            _images[i].gameObject.SetActive(false);
        }
    }
}