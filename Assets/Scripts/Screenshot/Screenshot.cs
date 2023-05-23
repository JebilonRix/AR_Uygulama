using System.Collections;
using UnityEngine;

public class Screenshot : MonoBehaviour
{
    //baktýðým tutorial https://www.youtube.com/watch?v=P3km_YZFz4A

    [SerializeField] private GameObject _UI;

    public void EkranGoruntusuAl()
    {
        // Arayüzü devre dýþý býrak
        _UI.SetActive(false);

        //Bug'ý önlemek için.
        StopCoroutine(GoruntuAl());

        //IEnumerator çalýþtýr.
        StartCoroutine(GoruntuAl());
    }

    private IEnumerator GoruntuAl()
    {
        // Bir sonraki kare sonuna kadar bekleyin
        yield return new WaitForEndOfFrame();

        // Ekran geniþliði ve yüksekliði kadar bir Texture2D nesnesi oluþturun
        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

        // Ekranýn tamamýný okuyun ve texture'a atayýn
        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        texture.Apply();

        // Ekran görüntüsü adýný belirleyin
        string goruntuAdi = "EkranGoruntusu_AR" + System.DateTime.Now.ToString() + ".png";

        // Texture2D'yi galeriye kaydedin. (Telefon için)
        NativeGallery.SaveImageToGallery(texture, "AR Albümü", goruntuAdi);

        // Texture2D'yi bellekten silin
        Destroy(texture);

        // Arayüzü tekrar etkinleþtir
        _UI.SetActive(true);
    }
}