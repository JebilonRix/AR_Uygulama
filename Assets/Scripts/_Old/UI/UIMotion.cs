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
        //Rect transform'u objeden alýyor. (Unutmalarý engellemek ve inspectorden ekleme iþlemini atlamak için)
        uiElement = GetComponent<RectTransform>();

        //Bu objeyi verilen baþlangýç pozisyonuna getirir.
        uiElement.position = startPosition;
    }

    private void Update()
    {
        //Sayaç, 2 frame arasýnda geçen süre kadar artýyor.
        timeElapsed += Time.deltaTime;

        //Bu metot oraný 0 ile 1 arasýnda kalmasýný saðlýyor.
        float t = Mathf.Clamp01(timeElapsed / duration);

        //uiElement (panel), iki nokta arasýnda hareket ettiriyor.
        uiElement.position = Vector3.Lerp(startPosition, targetPosition, t);

        //Bu scripti kapatýr. Devamlý hareket etmesini engeller. (Performans kazancý)
        if (t == 1f)
        {
            enabled = false;
        }
    }

    //Buton metotu
    public void ResetPosition()
    {
        //Sayacý sýfýrlýyor.
        timeElapsed = 0f;

        //Bu objeyi verilen baþlangýç pozisyonuna getirir.
        uiElement.position = startPosition;

        //Scripti aktive eder.
        enabled = true;
    }
}