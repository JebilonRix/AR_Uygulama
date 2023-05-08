using UnityEngine;

public class ChangeBuildingButton : MonoBehaviour
{
    [SerializeField] private GameObject _old;
    [SerializeField] private GameObject _new;

    private bool _isNewVersion = true;

    //Button metodu
    public void ChangeBuilding()
    {
        //bool de�erinin tezat�n� tekrar bool de�erine i�liyor.
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