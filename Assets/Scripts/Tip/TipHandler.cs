using TMPro;
using UnityEngine;

public class TipHandler : MonoBehaviour
{
    //[SerializeField] adlý komut class'da bulunan deðiþkenlerin public olmadan inspector'de görünmesini saðlar.
    //public'den kaçýnma sebebi diðer scriptlerden deðiþkene doðrudan müdahale edilmesini önlemek için.
    [SerializeField] private TextMeshProUGUI _textArea;

    //Singleton dizayn pattern: Sahnede sadece bir adet singleton'ý kurduðumuz MonoBehaviour'dan bulunmasýný saðlýyor.
    //Sahnedeki diðer objelerden doðrudan bu class'a ulaþýbiliyor.
    //Basit projeler (tek sahneli proje, küçük oyunlar için) kullanýþlýdýr. Fakat karmaþýk veya büyük projeler için pek tavsiye edilmez. Çünkü sahne baðýmlýlýðýný arttýr.
    public static TipHandler Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        //Unutmayý engellemek için.
        if (_textArea == null)
        {
            _textArea = GetComponentInChildren<TextMeshProUGUI>();
        }
    }

    public void ShowTip(string message)
    {
        //text area'ya string input'umuzu iþledik.
        _textArea.text = message;
    }

    public void ShowNothing()
    {
        //_text area'yý boþalttýk. (boþ string iþledik)
        _textArea.text = "";
    }
}