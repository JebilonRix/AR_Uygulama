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

    public void AlaniGoster()
    {
        BinayiGoster("Alan");
    }

    public void BinayiGoster(string binaAdi)
    {
        ARManager manager = ARManager.Instance;

        //AR panelini aktive ediyor.
        manager.SetActiveOnlyOnePanel("AR");

        //AR için taranmýþ alaný aktive ediyor.
        manager.SetActiveBuilding(binaAdi);
    }

    public void BinaDigerHaliGoster()
    {
        //Binanýn eski hali ve yeni hali arasýnda geçiþi saðlar.
        ARManager.Instance.SwitchBuilding();
    }

    public void AnaEkranaDon()
    {
        //Sadece ana ekraný açar. Diðer panelleri kapatýr.
        ARManager.Instance.SetActiveOnlyOnePanel("Main");
    }

    public void Cikis()
    {
        Application.Quit();
    }
}