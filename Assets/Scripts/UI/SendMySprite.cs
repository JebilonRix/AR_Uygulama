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
        //kendi objesindeki Image component ula��yor. Daha sonra oradaki sprite'n�n bilgilerini al�yor.
        Sprite sprite = _myImage.sprite;

        //MainImage adl� objemiz yoksa onu buluyor.
        if (_mainImage == null)
        {
            _mainImage = GameObject.FindGameObjectWithTag("MainImage").GetComponent<Image>();
        }

        //Main image adl� objenin Image component'ine, bilgilerini ald���m�z sprite'� at�yor.
        _mainImage.sprite = sprite;
    }
}