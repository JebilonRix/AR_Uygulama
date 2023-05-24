using UnityEngine;

[CreateAssetMenu(menuName = "ButtonMethods")]
public class ButtonMethods : ScriptableObject
{
    public void DokunmaBasladi(string binaAdi)
    {
        //Buttona dokunuldu�unda, o binan�n ad�n� ba�l��a yazar.
        ARManager.Instance.SetTitleText(binaAdi);
    }

    public void DokunmaBitti()
    {
        //Dokunma bitti�inde ba�l���n ad�n� varsay�lana d�nd�r�r.
        ARManager.Instance.SetTitleToDefault();
    }

    public void BilgiyiGoster(string infoBoxName)
    {
        ARManager manager = ARManager.Instance;

        //�stenilen info box'� belirtiyor.
        manager.SetActivateInfoBox(infoBoxName);

        //Info panelini aktive ediyor.
        manager.SetActivePanel("Info");

        //Infobox'taki yaz�sal bilgileri panele i�liyor.
        manager.SetInfoText();

        //Infobox'taki resimsel bilgileri panele i�liyor.
        manager.SetImages();
    }

    public void GeneliGoster()
    {
        ARManager manager = ARManager.Instance;

        //AR_Genel panelini aktive ediyor.
        manager.SetActiveOnlyOnePanel("AR_Genel");

        //AR i�in taranm�� alan� aktive ediyor.
        manager.SetActiveBuilding("Genel");
    }

    public void BinayiGoster()
    {
        ARManager manager = ARManager.Instance;

        //AR panelini aktive ediyor.
        manager.SetActiveOnlyOnePanel("AR_Bina");

        //AR i�in taranm�� binay� aktive ediyor.
        manager.SetActiveBuilding(manager.CurrentInfoBox.BinaAdi);
    }

    public void BinaDigerHaliGoster()
    {
        //Binan�n eski hali ve yeni hali aras�nda ge�i�i sa�lar.
        ARManager.Instance.SwitchBuilding();
    }

    public void AnaEkranaDon()
    {
        ARManager manager = ARManager.Instance;

        //Sadece ana ekran� a�ar. Di�er panelleri kapat�r.
        manager.SetActiveOnlyOnePanel("Main");

        //E�er herhangi bir bina veya genel g�r�n�m a��ksa o objeyi kapat�r.
        manager.DeactivateAllBuildings();
    }

    public void Cikis()
    {
        Application.Quit();
    }

    public void Bas()
    {
        Debug.Log("bas");
    }
}