using UnityEngine;

public class ChangeBuildingButton : MonoBehaviour
{
    [SerializeField] private GameObject _old;
    [SerializeField] private GameObject _new;

    private bool _isNewVersion = true;

    //Button metodu
    public void ChangeBuilding()
    {
        //bool deðerinin tezatýný tekrar bool deðerine iþliyor.
        _isNewVersion = !_isNewVersion;

        if (_isNewVersion)
        {
            _new.SetActive(true);
            _old.SetActive(false);
        }
        else
        {
            _new.SetActive(false);
            _old.SetActive(true);
        }
    }
}