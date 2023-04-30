using UnityEngine;
using UnityEngine.EventSystems;

public class TipSignal : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //yaz�lmas� istedi�im mesaj
    [SerializeField] private string message;

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Tip handle singelton'a ula� ve showtip adl� methodu �a��r. 
        TipHandler.Instance.ShowTip(message);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Tip handle singelton'a ula� ve ShowNothing adl� methodu �a��r. 
        TipHandler.Instance.ShowNothing();
    }
}