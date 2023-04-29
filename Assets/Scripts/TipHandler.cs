using TMPro;
using UnityEngine;

public class TipHandler : MonoBehaviour
{
    //[SerializeField] adl� komut class'da bulunan de�i�kenlerin public olmadan inspector'de g�r�nmesini sa�lar.
    //public'den ka��nma sebebi di�er scriptlerden de�i�kene do�rudan m�dahale edilmesini �nlemek i�in.
    [SerializeField] private TextMeshProUGUI _textArea;

    //Singleton dizayn pattern: Sahnede sadece bir adet singleton'� kurdu�umuz MonoBehaviour'dan bulunmas�n� sa�l�yor.
    //Sahnedeki di�er objelerden do�rudan bu class'a ula��biliyor.
    //Basit projeler (tek sahneli proje, k���k oyunlar i�in) kullan��l�d�r. Fakat karma��k veya b�y�k projeler i�in pek tavsiye edilmez. ��nk� sahne ba��ml�l���n� artt�r.
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
        //Unutmay� engellemek i�in.
        if (_textArea == null)
        {
            _textArea = GetComponentInChildren<TextMeshProUGUI>();
        }
    }

    public void ShowTip(string message)
    {
        //text area'ya string input'umuzu i�ledik.
        _textArea.text = message;
    }

    public void ShowNothing()
    {
        //_text area'y� bo�altt�k. (bo� string i�ledik)
        _textArea.text = "";
    }
}