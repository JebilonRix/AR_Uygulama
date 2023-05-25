using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "New Info Box", menuName = "InfoBox")]
public class InfoBox : ScriptableObject
{
    [Header("Binanýn Bilgileri")]
    [SerializeField] private string _binaAdi;
    [SerializeField] private string _binaTarih;
    [SerializeField] private string _binaRestorasyonTarihi;
    [SerializeField] private string _binaYapimSistemi;
    [SerializeField] private string _binaAciklama;

    [Header("Binanýn Resimleri")]
    [SerializeField] private Material[] _binaResimler;
    [SerializeField] private Material _binaBilgiMaterial;
    [SerializeField] private VideoClip _videoclip;

    public string BinaAdi { get => _binaAdi; }
    public string BinaTarih { get => _binaTarih; }
    public string BinaRestorasyonTarihi { get => _binaRestorasyonTarihi; }
    public string BinaYapimSistemi { get => _binaYapimSistemi; }
    public string BinaAciklama { get => _binaAciklama; }
    public Material[] BinaResimler { get => _binaResimler; }
    public VideoClip Videoclip { get => _videoclip; }
    public Material BinaBilgiMaterial { get => _binaBilgiMaterial; private set => _binaBilgiMaterial = value; }
}