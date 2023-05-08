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
        //yazýsal verileri iþliyorum.
        SetText(infoBox);

        //kaç tane resim varsa o kadar nesneye bu resimleri atayacaðýz.
        for (int i = 0; i < infoBox.BinaResimler.Length; i++)
        {
            _images[i].sprite = infoBox.BinaResimler[i];
        }

        //Ana resim olarak, infobox'a eklenen ilk resmi getir.
        _mainImage.sprite = infoBox.BinaResimler[0];

        if (infoBox.Videoclip != null)
        {
            //video iþleme
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
            $"Açýklama: {infoBox.BinaAciklama}\n";

        _textArea.text = yazi;
    }
}