using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "New Info Box", menuName = "InfoBox")]
public class InfoBox : ScriptableObject
{
    [Header("Binanýn Bilgileri")]
    [SerializeField] private int _binaEnvanterNo;
    [SerializeField] private string _binaAdi;
    [SerializeField] private string _binaTarih;
    [SerializeField] private string _binaAciklama;
    [SerializeField] private string _binaYapimSistemi;
    [SerializeField] private string _binaRestorasyonTarihi;

    [Header("Binanýn Resimleri")]
    [SerializeField] private Sprite _binaAnaResmi;
    [SerializeField] private Sprite[] _binaResimler;
    [SerializeField] private VideoClip _videoclip;

    public int BinaEnvanterNo { get => _binaEnvanterNo; }
    public string BinaAdi { get => _binaAdi; }
    public string BinaTarih { get => _binaTarih; }
    public string BinaAciklama { get => _binaAciklama; }
    public string BinaYapimSistemi { get => _binaYapimSistemi; }
    public string BinaRestorasyonTarihi { get => _binaRestorasyonTarihi; }
    public Sprite BinaAnaResmi { get => _binaAnaResmi; }
    public Sprite[] BinaResimler { get => _binaResimler; }
    public VideoClip Videoclip { get => _videoclip; }
}