using UnityEngine;
using UnityEngine.UI;

public class SendMySprite : MonoBehaviour
{
    private Image _myImage = null;
    private Image _mainImage = null;

    private void Start()
    {
        //Kendi game objesindeki image component'ini bulacak.
        _myImage = GetComponent<Image>();
    }

    public void Send()
    {
        //kendi objesindeki Image component ulaþýyor. Daha sonra oradaki sprite'nýn bilgilerini alýyor.
        Sprite sprite = _myImage.sprite;

        //MainImage adlý objemiz yoksa onu buluyor.
        if (_mainImage == null)
        {
            _mainImage = GameObject.FindGameObjectWithTag("MainImage").GetComponent<Image>();
        }

        //Main image adlý objenin Image component'ine, bilgilerini aldýðýmýz sprite'ý atýyor.
        _mainImage.sprite = sprite;
    }
}