using UnityEngine;
using UnityEngine.EventSystems;

public class TipSignal : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //yazýlmasý istediðim mesaj
    [SerializeField] private string message;

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Tip handle singelton'a ulaþ ve showtip adlý methodu çaðýr. 
        TipHandler.Instance.ShowTip(message);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Tip handle singelton'a ulaþ ve ShowNothing adlý methodu çaðýr. 
        TipHandler.Instance.ShowNothing();
    }
}