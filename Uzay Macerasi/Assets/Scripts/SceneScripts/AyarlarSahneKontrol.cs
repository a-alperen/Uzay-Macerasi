using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AyarlarSahneKontrol : MonoBehaviour
{
    public Button kolayButon, ortaButon, zorButon;

    // Start is called before the first frame update
    void Start()
    {
        if(OyunKayit.KolayDegerOku() == 1)
        {
            kolayButon.interactable = false;
            ortaButon.interactable = true;
            zorButon.interactable = true;
        }
        if(OyunKayit.OrtaDegerOku() == 1)
        {
            kolayButon.interactable = true;
            ortaButon.interactable = false;
            zorButon.interactable = true;
        }
        if(OyunKayit.ZorDegerOku() == 1)
        {
            kolayButon.interactable = true;
            ortaButon.interactable = true;
            zorButon.interactable = false;
        }
    }

    public void SecenekSecildi(string seviye)
    {
        switch (seviye)
        {
            case "Kolay":
                OyunKayit.KolayDegerAta(1);
                OyunKayit.OrtaDegerAta(0);
                OyunKayit.ZorDegerAta(0);
                kolayButon.interactable = false;
                ortaButon.interactable = true;
                zorButon.interactable = true;
                break;
            case "Orta":
                OyunKayit.KolayDegerAta(0);
                OyunKayit.OrtaDegerAta(1);
                OyunKayit.ZorDegerAta(0);
                kolayButon.interactable = true;
                ortaButon.interactable = false;
                zorButon.interactable = true;
                break;
            case "Zor":
                OyunKayit.KolayDegerAta(0);
                OyunKayit.OrtaDegerAta(0);
                OyunKayit.ZorDegerAta(1);
                kolayButon.interactable = true;
                ortaButon.interactable = true;
                zorButon.interactable = false;
                break;
            default:
                break;
        }
    }

    public void AnaMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
