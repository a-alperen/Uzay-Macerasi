using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    PolygonCollider2D polygonCollider2D;

    bool hareket;

    float min, max;

    float randomHiz;
    public bool Hareket
    {
        get { return hareket; }
        set { hareket = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        

        if (OyunKayit.KolayDegerOku() == 1)
        {
            randomHiz = Random.Range(0.2f, 0.8f);
        }
        if (OyunKayit.OrtaDegerOku() == 1)
        {
            randomHiz = Random.Range(0.5f, 1.0f);
        }
        if (OyunKayit.ZorDegerOku() == 1)
        {
            randomHiz = Random.Range(0.8f, 1.5f);
        }

        float objegenislik = polygonCollider2D.bounds.size.x / 2;

        if (transform.position.x > 0)
        {
            
            min = objegenislik;
            max = EkranHesaplayicisi.instance.Genislik - objegenislik;
        }
        else
        {
            min = -EkranHesaplayicisi.instance.Genislik + objegenislik;
            max = -objegenislik;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hareket)
        {
            float pingPongX = Mathf.PingPong(randomHiz * Time.time, max - min) + min;
            Vector2 pingPong = new Vector2(pingPongX, transform.position.y);
            transform.position = pingPong;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ayaklar"))
        {
            GameObject.FindGameObjectWithTag("Player").transform.parent = transform;
            GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<OyuncuHareket>().ZiplamayiSifirla();
        }
        
    }
}
