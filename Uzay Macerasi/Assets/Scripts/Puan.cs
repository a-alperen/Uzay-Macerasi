using UnityEngine;
using UnityEngine.UI;

public class Puan : MonoBehaviour
{
    [SerializeField]
    Text puanText = default;
    [SerializeField]
    Text altinText = default;

    [SerializeField]
    Text oyunBittiPuanText = default;
    [SerializeField]
    Text oyunBittiAltinText = default;

    int puan;
    int enYuksekPuan;
    
    int altin;
    int enYuksekAltin;

    bool puanTopla = true;
    // Start is called before the first frame update
    void Start()
    {
        altinText.text = " X " + altin;
    }

    // Update is called once per frame
    void Update()
    {
        if (puanTopla)
        {
            puan = (int)Camera.main.transform.position.y;
            puanText.text = "Puan: " + puan;
        }
        
    }

    public void AltinKazan()
    {
        FindObjectOfType<SesKontrol>().AltinSes();
        altin++;
        altinText.text = " X " + altin;
    }

    public void OyunBitti()
    {
        if(OyunKayit.KolayDegerOku() == 1)
        {
            enYuksekPuan = OyunKayit.KolayPuanDegerOku();
            enYuksekAltin = OyunKayit.KolayAltinDegerOku();

            if (puan > enYuksekPuan)
            {
                OyunKayit.KolayPuanDegerAta(puan);
            }
            if (altin > enYuksekAltin)
            {
                OyunKayit.KolayAltinDegerAta(altin);
            }
        }
        if (OyunKayit.OrtaDegerOku() == 1)
        {
            enYuksekPuan = OyunKayit.OrtaPuanDegerOku();
            enYuksekAltin = OyunKayit.OrtaAltinDegerOku();

            if (puan > enYuksekPuan)
            {
                OyunKayit.OrtaPuanDegerAta(puan);
            }
            if (altin > enYuksekAltin)
            {
                OyunKayit.OrtaAltinDegerAta(altin);
            }
        }
        if (OyunKayit.ZorDegerOku() == 1)
        {
            enYuksekPuan = OyunKayit.ZorPuanDegerOku();
            enYuksekAltin = OyunKayit.ZorAltinDegerOku();

            if (puan > enYuksekPuan)
            {
                OyunKayit.ZorPuanDegerAta(puan);
            }
            if (altin > enYuksekAltin)
            {
                OyunKayit.ZorAltinDegerAta(altin);
            }
        }


        puanTopla = false;
        oyunBittiPuanText.text = "Puan: " + puan;
        oyunBittiAltinText.text = "X " + altin;
    }
}
