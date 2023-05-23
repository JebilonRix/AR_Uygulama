using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class UIMotion : MonoBehaviour
{
    [SerializeField] private Vector3 startPosition = new Vector3(-290, 540);
    [SerializeField] private Vector3 targetPosition = new Vector3(286, 540);
    [SerializeField] private float duration = 1f;

    private RectTransform uiElement;
    private float timeElapsed = 0f;

    private void Awake()
    {
        //Rect transform'u objeden al�yor. (Unutmalar� engellemek ve inspectorden ekleme i�lemini atlamak i�in)
        uiElement = GetComponent<RectTransform>();

        //Bu objeyi verilen ba�lang�� pozisyonuna getirir.
        uiElement.position = startPosition;
    }

    private void Update()
    {
        //Saya�, 2 frame aras�nda ge�en s�re kadar art�yor.
        timeElapsed += Time.deltaTime;

        //Bu metot oran� 0 ile 1 aras�nda kalmas�n� sa�l�yor.
        float t = Mathf.Clamp01(timeElapsed / duration);

        //uiElement (panel), iki nokta aras�nda hareket ettiriyor.
        uiElement.position = Vector3.Lerp(startPosition, targetPosition, t);

        //Bu scripti kapat�r. Devaml� hareket etmesini engeller. (Performans kazanc�)
        if (t == 1f)
        {
            enabled = false;
        }
    }

    //Buton metotu
    public void ResetPosition()
    {
        //Sayac� s�f�rl�yor.
        timeElapsed = 0f;

        //Bu objeyi verilen ba�lang�� pozisyonuna getirir.
        uiElement.position = startPosition;

        //Scripti aktive eder.
        enabled = true;
    }
}