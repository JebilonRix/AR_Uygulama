using UnityEngine;

[CreateAssetMenu(menuName = "ButtonMethods")]
public class ButtonMethods : ScriptableObject
{
    public void DokunmaBasladi(string binaAdi)
    {
        //Buttona dokunulduðunda, o binanýn adýný baþlýða yazar.
        ARManager.Instance.SetTitleText(binaAdi);
    }

    public void DokunmaBitti()
    {
        //Dokunma bittiðinde baþlýðýn adýný varsayýlana döndürür.
        ARManager.Instance.SetTitleToDefault();
    }

    public void BilgiyiGoster(string infoBoxName)
    {
        ARManager manager = ARManager.Instance;

        //Ýstenilen info box'ý belirtiyor.
        manager.SetActivateInfoBox(infoBoxName);

        //Info panelini aktive ediyor.
        manager.SetActivePanel("Info");

        //Infobox'taki yazýsal bilgileri panele iþliyor.
        manager.SetInfoText();

        //Infobox'taki resimsel bilgileri panele iþliyor.
        manager.SetImages();
    }

    public void GeneliGoster()
    {
        ARManager manager = ARManager.Instance;

        //AR_Genel panelini aktive ediyor.
        manager.SetActiveOnlyOnePanel("AR_Genel");

        //AR için taranmýþ alaný aktive ediyor.
        manager.SetActiveBuilding("Genel");
    }

    public void BinayiGoster()
    {
        ARManager manager = ARManager.Instance;

        //AR panelini aktive ediyor.
        manager.SetActiveOnlyOnePanel("AR_Bina");

        //AR için taranmýþ binayý aktive ediyor.
        manager.SetActiveBuilding(manager.CurrentInfoBox.BinaAdi);
    }

    public void BinaDigerHaliGoster()
    {
        //Binanýn eski hali ve yeni hali arasýnda geçiþi saðlar.
        ARManager.Instance.SwitchBuilding();
    }

    public void AnaEkranaDon()
    {
        ARManager manager = ARManager.Instance;

        //Sadece ana ekraný açar. Diðer panelleri kapatýr.
        manager.SetActiveOnlyOnePanel("Main");

        //Eðer herhangi bir bina veya genel görünüm açýksa o objeyi kapatýr.
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