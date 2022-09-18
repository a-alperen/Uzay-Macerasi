using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PuanSahneKontrol : MonoBehaviour
{

    public Text kolayPuan, kolayAltin, ortaPuan, ortaAltin, zorPuan, zorAltin;
    // Start is called before the first frame update
    void Start()
    {
        kolayPuan.text = "Puan: " + OyunKayit.KolayPuanDegerOku();
        kolayAltin.text = "X " + OyunKayit.KolayAltinDegerOku();

        ortaPuan.text = "Puan: " + OyunKayit.OrtaPuanDegerOku();
        ortaAltin.text = "X " + OyunKayit.OrtaAltinDegerOku();

        zorPuan.text = "Puan: " + OyunKayit.ZorPuanDegerOku();
        zorAltin.text = "X " + OyunKayit.ZorAltinDegerOku();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AnaMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
