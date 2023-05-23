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

    public void AlaniGoster()
    {
        BinayiGoster("Alan");
    }

    public void BinayiGoster(string binaAdi)
    {
        ARManager manager = ARManager.Instance;

        //AR panelini aktive ediyor.
        manager.SetActiveOnlyOnePanel("AR");

        //AR i�in taranm�� alan� aktive ediyor.
        manager.SetActiveBuilding(binaAdi);
    }

    public void BinaDigerHaliGoster()
    {
        //Binan�n eski hali ve yeni hali aras�nda ge�i�i sa�lar.
        ARManager.Instance.SwitchBuilding();
    }

    public void AnaEkranaDon()
    {
        //Sadece ana ekran� a�ar. Di�er panelleri kapat�r.
        ARManager.Instance.SetActiveOnlyOnePanel("Main");
    }

    public void Cikis()
    {
        Application.Quit();
    }
}