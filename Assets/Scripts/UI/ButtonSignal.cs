using UnityEngine;

public class ButtonSignal : MonoBehaviour
{
    public void OpenInfoPanelSignal(InfoBox infoBox)
    {
        if (infoBox != null)
        {
            //Verilen infoBox'u manager'a iþleyecek ve infobox'ýn içindeki verilere ulaþabilmemizi saðlayacak.
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
        //verilen index'teki binayý açacak.
        Manager.Instance.ActivateBuilding(buildingIndex);

        //AR panelini aktive edecek.
        Manager.Instance.ActivatePanel(2);
    }

    public void ToSelectionPanelSignal()
    {
        //Selection panelini aktive edecek.
        Manager.Instance.ActivatePanel(0);

        //Tüm binalarý kapatacak.
        Manager.Instance.ActivateBuilding(-1);

        //AR alanýný kapatýr.
        Manager.Instance.DeactivateField();
    }

    public void ShowARField()
    {
        //Selection panelini aktive edecek.
        Manager.Instance.ActivatePanel(3);

        //AR alanýný açar.
        Manager.Instance.ActivateField();
    }
}