using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "New Info Box", menuName = "InfoBox")]
public class InfoBox : ScriptableObject
{
    [Header("Binanın Bilgileri")]
    [SerializeField] private int _binaEnvanterNo;
    [SerializeField] private string _binaAdi;
    [SerializeField] private string _binaTarih;
    [SerializeField] private string _binaAciklama;
    [SerializeField] private string _binaYapimSistemi;
    [SerializeField] private string _binaRestorasyonTarihi;

    [Header("Binanın Resimleri")]
    [SerializeField] private Sprite _binaAnaResmi;
    [SerializeField] private Sprite[] _binaResimler;
    [SerializeField] private VideoClip _videoclip;

    public string BinaAdi { get => _binaAdi; }
    public string BinaTarih { get => _binaTarih; }
}