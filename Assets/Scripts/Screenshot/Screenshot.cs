using System.Collections;
using UnityEngine;

public class Screenshot : MonoBehaviour
{
    //bakt���m tutorial https://www.youtube.com/watch?v=P3km_YZFz4A

    [SerializeField] private GameObject _UI;

    public void EkranGoruntusuAl()
    {
        // Aray�z� devre d��� b�rak
        _UI.SetActive(false);

        //Bug'� �nlemek i�in.
        StopCoroutine(GoruntuAl());

        //IEnumerator �al��t�r.
        StartCoroutine(GoruntuAl());
    }

    private IEnumerator GoruntuAl()
    {
        // Bir sonraki kare sonuna kadar bekleyin
        yield return new WaitForEndOfFrame();

        // Ekran geni�li�i ve y�ksekli�i kadar bir Texture2D nesnesi olu�turun
        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

        // Ekran�n tamam�n� okuyun ve texture'a atay�n
        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        texture.Apply();

        // Ekran g�r�nt�s� ad�n� belirleyin
        string goruntuAdi = "EkranGoruntusu_AR" + System.DateTime.Now.ToString() + ".png";

        // Texture2D'yi galeriye kaydedin. (Telefon i�in)
        NativeGallery.SaveImageToGallery(texture, "AR Alb�m�", goruntuAdi);

        // Texture2D'yi bellekten silin
        Destroy(texture);

        // Aray�z� tekrar etkinle�tir
        _UI.SetActive(true);
    }
}