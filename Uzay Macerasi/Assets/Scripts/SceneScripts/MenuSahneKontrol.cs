using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSahneKontrol : MonoBehaviour
{
    [SerializeField]
    Sprite[] muzikIkonlar = default;
    [SerializeField]
    Button muzikButon = default;

    
    // Start is called before the first frame update
    void Start()
    {
        if(OyunKayit.ZorlukKayitVarmi() == false)
        {
            OyunKayit.KolayDegerAta(1);
        }
        
        if(OyunKayit.MuzikAcikKayitVarmi() == false)
        {
            OyunKayit.MuzikAcikDegerAta(1);
        }

        MuzikAyarlariniDenetle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OyunuBaslat()
    {
        SceneManager.LoadScene("Oyun");
    }

    public void EnYuksekPuan()
    {
        SceneManager.LoadScene("Puan");
    }

    public void Ayarlar()
    {
        SceneManager.LoadScene("Ayarlar");
    }

    public void Muzik()
    {
        if (OyunKayit.MuzikAcikDegerOku() == 1)
        {
            OyunKayit.MuzikAcikDegerAta(0);
            MuzikKontrol.instance.MuzikCal(false);
            muzikButon.image.sprite = muzikIkonlar[0];
        }
        else
        {
            OyunKayit.MuzikAcikDegerAta(1);
            MuzikKontrol.instance.MuzikCal(true);
            muzikButon.image.sprite = muzikIkonlar[1];
        }
    }

    void MuzikAyarlariniDenetle()
    {
        if(OyunKayit.MuzikAcikDegerOku() == 1)
        {
            MuzikKontrol.instance.MuzikCal(true);
            muzikButon.image.sprite = muzikIkonlar[1];
        }
        else
        {
            MuzikKontrol.instance.MuzikCal(false);
            muzikButon.image.sprite = muzikIkonlar[0];
        }
    }
}
