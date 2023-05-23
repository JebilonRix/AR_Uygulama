using UnityEngine;

public class ButtonSignal : MonoBehaviour
{
    public void OpenInfoPanelSignal(InfoBox infoBox)
    {
        if (infoBox != null)
        {
            //Verilen infoBox'u manager'a i�leyecek ve infobox'�n i�indeki verilere ula�abilmemizi sa�layacak.
            Manager.Instance.CurrentInfoBox = infoBox;
        }

        //Info panelini aktive edecek.
        Manager.Instance.ActivatePanel(1);
    }

    public void CloseInfoPanelSignal()
    {
        //Info panelini aktive edecek.
        Manager.Instance.ActivatePanel(0);
    }

    public void ShowBuildingInARSignal(int buildingIndex)
    {
        //verilen index'teki binay� a�acak.
        Manager.Instance.ActivateBuilding(buildingIndex);

        //AR panelini aktive edecek.
        Manager.Instance.ActivatePanel(2);
    }

    public void ToSelectionPanelSignal()
    {
        //Selection panelini aktive edecek.
        Manager.Instance.ActivatePanel(0);

        //T�m binalar� kapatacak.
        Manager.Instance.ActivateBuilding(-1);

        //AR alan�n� kapat�r.
        Manager.Instance.DeactivateField();
    }

    public void ShowARField()
    {
        //Selection panelini aktive edecek.
        Manager.Instance.ActivatePanel(3);

        //AR alan�n� a�ar.
        Manager.Instance.ActivateField();
    }
}